using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.Wiki.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Text.RegularExpressions;

namespace ReleaseBranchUtilityLib
{
    public class ReleaseBranchAdder
    {
        /// <returns>An integer which is 0 on success or 1 otherwise, not a bool so that we can expand the range of codes at a later time</returns>
        public static int Execute(string collectionUri, string projectName, string repoName, string commitId, int releaseNumber, char? releaseLetter, bool force, Action<string> log)
        {
            (var connection, var project) = GetConnectionAndProject(collectionUri, projectName);

            return
                CreateBranch(releaseNumber, releaseLetter, project, repoName, commitId, force, connection, log)
                && UpdateBuilds(releaseNumber, releaseLetter, project, connection, log)
                && BuildQueuer.QueueCIBuilds(project.Id, connection, log)
                //&& UpdateWiki(releaseNumber, releaseLetter, project, connection, log)
                ? 0 : 1;
        }

        public static GitHttpClient GitClient(VssConnection connection) {  return connection.GetClient<GitHttpClient>(); } 

        private static bool CreateBranch(int releaseNumber, char? releaseLetter, TeamProject project, string repoName, string commitId, bool force, VssConnection connection, Action<string> log)
        {
            using GitHttpClient gitClient = GitClient(connection);

            var repo = gitClient.GetRepositoryAsync(project.Name, repoName).Result;

            var branches = gitClient.GetRefsAsync(project: project.Name, repositoryId: repoName).Result;
            if (branches.Any(r => r.Name.ToLower().EndsWith(BranchName(releaseNumber, releaseLetter).ToLower())))
            {
                if (!force)
                {
                    Fail("Branch already exists and force not set", log);
                    return false;
                }

                log($"Found branch {BranchName(releaseNumber, releaseLetter)} and continuing as Force was set");
            }
            else
            {
                var sourceCommit = FindCommit(project, repoName, commitId, gitClient, log);

                GitRefUpdateResult refCreateResult = gitClient.UpdateRefsAsync(
                    new GitRefUpdate[] {
                    new GitRefUpdate() {
                        OldObjectId = new string('0', 40),
                        NewObjectId = sourceCommit.CommitId,
                        Name = $"refs/heads/Release/{BranchName(releaseNumber, releaseLetter)}",
                    }
                    },
                    repositoryId: repo.Id).Result.First();

                if (!refCreateResult.Success && refCreateResult.UpdateStatus != GitRefUpdateStatus.StaleOldObjectId)
                {
                    Fail($"Failed to create the new branch: {refCreateResult.CustomMessage}", log);
                    return false;
                }

                log($"Created branch: {BranchName(releaseNumber, releaseLetter)}");
            }
            return true;
        }

        public static GitCommitRef FindCommit(TeamProject project, string repoName, string commitId, GitHttpClient gitClient, Action<string> log)
        {
            if (commitId == null || commitId.Length != 40)
            {
                Fail("Need to create the branch but the commit id is missing or malformed.  It must be the full 40 character commit identifier.", log);
                return null;
            }

            var criteria = new GitQueryCommitsCriteria { ItemVersion = new GitVersionDescriptor { Version = commitId, VersionType = GitVersionType.Commit, VersionOptions = GitVersionOptions.None } };
            var sourceCommits = gitClient.GetCommitsAsync(project: project.Name, repositoryId: repoName, searchCriteria: criteria).Result.Where(c => c.CommitId == commitId);

            if (sourceCommits.Count() != 1)
            {
                Fail("Cannot find exactly one commit, source doubtful", log);
                return null;
            }

            log("Found the source commit");

            return sourceCommits.First(); ;

        }
        private static bool UpdateBuilds(int releaseNumber, char? releaseLetter, TeamProject project, VssConnection connection, Action<string> log)
        {
            BuildHttpClient buildClient = connection.GetClient<BuildHttpClient>();

            Regex regex = new Regex(@"^RB[0-9]+[a-z]?[\s]+(.*)$");

            var definitions = buildClient.GetDefinitionsAsync(project.Id).Result;
            var definitionsMatchingRegex = definitions.Where(d => regex.Match(d.Name).Success);
            string newBranch = $"refs/heads/Release/{BranchName(releaseNumber, releaseLetter)}";

            definitionsMatchingRegex.ForEach(d =>
                {
                    var def = buildClient.GetDefinitionAsync(d.Project.Id, d.Id).Result;
                    var match = regex.Match(def.Name);
                    string newName = BuildName(releaseNumber, releaseLetter, match.Groups[1].Value);

                    // only update the build if it needs updating to avoid the history becoming quite long over time if this gets rerun
                    // on existing branches to update the wiki.
                    bool updated = false;
                    if (def.Repository.DefaultBranch != newBranch) { def.Repository.DefaultBranch = newBranch; updated = true; }
                    if (def.Name != newName) { def.Name = newName; updated = true; }

                    foreach (var trigger in def.Triggers.Where(t => t is ContinuousIntegrationTrigger))
                    {
                        var ciTrigger = ((ContinuousIntegrationTrigger)trigger);
                        for (int filterLoop = 0; filterLoop < ciTrigger.BranchFilters.Count; filterLoop++)
                        {
                            if (!ciTrigger.BranchFilters[filterLoop].EndsWith(newBranch))
                            {
                                ciTrigger.BranchFilters[filterLoop] = $"+{newBranch}";
                                updated = true;
                            }
                        }
                    }
                    foreach (var trigger in def.Triggers.Where(t => t is ScheduleTrigger))
                    {
                        var sTrigger = ((ScheduleTrigger)trigger);

                        foreach (var schedule in sTrigger.Schedules)
                        {
                            for (int filterLoop = 0; filterLoop < schedule.BranchFilters.Count; filterLoop++)
                            {
                                if (!schedule.BranchFilters[filterLoop].EndsWith(newBranch))
                                {
                                    schedule.BranchFilters[filterLoop] = $"+{newBranch}";
                                    updated = true;
                                }
                            }
                        }
                    }

                    if (updated)
                    {
                        def.Comment = "Updated by ReleaseCandidateApp";
                        var newDef = buildClient.UpdateDefinitionAsync(def).Result;
                        log($"Updated build definition {def.Id} now called {def.Name}");
                    }
                    else
                    {
                        log($"Build definition {def.Id} called {def.Name} found but didn't need updating");
                    }
                });

            return true;
        }

        private static bool UpdateWiki(int releaseNumber, char? releaseLetter, TeamProject project, VssConnection connection, Action<string> log)
        {
            using WikiHttpClient wikiClient = connection.GetClient<WikiHttpClient>();

            (var tagFound, var workItemIds) = FindWorkItemsWithTag(TagName(releaseNumber,releaseLetter), project, connection, log);
            if (!tagFound)
            {
                return false;
            }

            log("Updating Wiki with results");

            List<WikiV2> wikis = wikiClient.GetAllWikisAsync(project.Id).SyncResult();
            var wiki = wikis.First();

            var rootPageResponse = wikiClient.GetPageAsync(
                project: wiki.ProjectId,
                wikiIdentifier: wiki.Id,
                path: "/Release Notes",
                includeContent: true,
                recursionLevel: VersionControlRecursionType.OneLevel).SyncResult(); //.Page;

            var rootPage = rootPageResponse.Page;

            string originalContent = rootPage.Content;
            string newContent = @$"
#Release {releaseNumber}{releaseLetter}

Change Window: 
Service Outage: No
Change Reference: 
Deployment OAT: RB{releaseNumber} - CD to OAT
Deployment Live: RB{releaseNumber} - CD to LIVE
";


            workItemIds.ForEach(wi => newContent += $"#{wi}\n");

            newContent += "\n---\n";
            newContent += originalContent;

            WikiPageResponse editedPageResponse = wikiClient.CreateOrUpdatePageAsync(
                parameters: new WikiPageCreateOrUpdateParameters { Content = newContent },
                project: project.Id,
                wikiIdentifier: wiki.Name,
                path: rootPage.Path,
                Version: rootPageResponse.ETag.ToList()[0]).SyncResult();

            return true;
        }

        private static (bool, IEnumerable<int>) FindWorkItemsWithTag(string tagName, TeamProject project, VssConnection connection, Action<string> log)
        {
            using TaggingHttpClient taggingClient = connection.GetClient<TaggingHttpClient>();
            using WorkItemTrackingHttpClient workItemTrackingClient = connection.GetClient<WorkItemTrackingHttpClient>();

            var tags = taggingClient.GetTagsAsync(project.Id).Result.Where(t => t.Name == tagName);
            if (tags.Count() != 1)
            {
                Fail($"We have found {tags.Count()} tag(s) called {tagName} which isn't the expected 1", log);
                return (false, null);
            }

            var tag = tags.First();

            log($"Finding stories tagged with {tag.Name} for this release");

            Wiql wiql = new Wiql()
            {
                Query = "Select [Id] " +
                        "From WorkItems " +
                        "Where [Work Item Type] = 'Product Backlog Item' " +
                        $"And [Tags] contains '{tag.Name}' " +
                        "Order By [Id]"
            };

            var queryResults = workItemTrackingClient.QueryByWiqlAsync(wiql: wiql, project: project.Id).Result;
            var ids = queryResults.WorkItems.Select(i => i.Id);

            log($"Found {ids.Count()} for this release, which " + ((ids.Count() == 1) ? "is" : "are"));
            ids.ForEach(wi => log($"#{wi}"));
            return (true, ids);
        }

        private static void Fail(string reason, Action<string> log)
        {
            log($"Failed: {reason}");
        }

        public static (VssConnection, TeamProject) GetConnectionAndProject(string collectionUri, string ProjectName)
        {
            // Interactively ask the user for credentials, caching them so the user isn't constantly prompted
            var creds = new VssClientCredentials();
            creds.Storage = new VssClientCredentialStorage();

            // Connect to Azure DevOps Services
            var connection = new VssConnection(new Uri(collectionUri), creds);

            ProjectHttpClient projectClient = connection.GetClient<ProjectHttpClient>();
            var project = projectClient.GetProject(ProjectName).Result;

            return (connection, project);
        }

        /// <summary>
        /// Release letter was removed from the return string as at this point all branches will be numbers only and further live patches
        /// will be done on the same release branch as the original live release.  This may change and so this was left in.
        /// </summary>
        private static string BranchName(int releaseNumber, char? releaseLetter) => $"Release-{releaseNumber}";
        private static string BuildName(int releaseNumber, char? releaseLetter, string text) => $"RB{releaseNumber} {text}";
        private static string TagName(int releaseNumber, char? releaseLetter) => $"R{releaseNumber}{releaseLetter}";
    }
}
