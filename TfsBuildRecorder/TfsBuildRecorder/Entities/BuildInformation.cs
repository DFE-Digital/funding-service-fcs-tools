using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Common;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using TfsBuildRecorder.Helpers;

namespace TfsBuildRecorder.Entities
{
    internal class BuildInformation
    {
        private readonly string _tfsServerName = ConfigurationManager.AppSettings["TfsServerName"];
        public List<TfsBuildDetail> KeyBuildList { get; set; }

        public List<string> BrokenBuilds { get; set; }

        public List<TfsBuildDetail> BuildList { get; set; }

        public string TfsServerName
        {
            get { return _tfsServerName; }
        }

        public void TfsDataPicker()
        {
            var tfsCred = CredentialManager.GetTfsCredentials();
            
            //Connect to TFS build server
            var tfsUri = new Uri(TfsServerName);
            var tfs = new TfsTeamProjectCollection(tfsUri, tfsCred);

            tfs.Authenticate();
            var buildServer = (IBuildServer)tfs.GetService(typeof(IBuildServer));

            //Specify query
            var spec = buildServer.CreateBuildDetailSpec("*");
            spec.InformationTypes = new List<string> { InformationTypes.BuildWarning, InformationTypes.AssociatedChangeset }.ToArray();

            // for speed improvement
            spec.MinFinishTime = DateTime.Now.AddDays(-28); //to get only builds of last 4 weeks
            //spec.MaxBuildsPerDefinition = 5; //get only this many builds per build definintion
            spec.QueryOrder = BuildQueryOrder.FinishTimeDescending; //get the latest build only
            spec.QueryOptions = QueryOptions.All;

            var builds = buildServer.QueryBuilds(spec).Builds;
            var buildlist = (from buildDetail in builds
                let buildDefinition = buildDetail.BuildDefinition
                where buildDefinition != null
                let build = new TfsBuildDetail
                             {
                                 DefinitionName = buildDefinition != null ? buildDefinition.Name : buildDetail.LabelName.Substring(0, buildDetail.LabelName.LastIndexOf('$')),
                                 FinishTime = buildDetail.FinishTime,
                                 LabelName = buildDetail.LabelName,
                                 LastGoodLabelName = buildDefinition.LastGoodBuildLabel,
                                 RequestedFor = buildDetail.RequestedFor,
                                 StartTime = buildDetail.StartTime,
                                 Status = buildDetail.Status,
                                 TestStatus = buildDetail.TestStatus,
                                 TestRunList = new List<BuildTestRun>(GetTestResult(buildDetail.Uri, tfs)),
                                 Warnings = buildDetail.Information.GetNodesByType(InformationTypes.BuildWarning, false).Count()
                             }
                             let changesets = buildDetail.Information.GetNodesByType(InformationTypes.AssociatedChangeset)
                             select build).ToList();

            BuildList = new List<TfsBuildDetail>(buildlist);
            BrokenBuilds =
                new List<string>(
                    buildlist.Where(x => x.Status != BuildStatus.Succeeded && x.Status != BuildStatus.InProgress)
                        .Select(y => y.DefinitionName + " by " + y.RequestedFor));
            KeyBuildList = new List<TfsBuildDetail>(buildlist.Where(x =>
                x.DefinitionName == "Main CD to CI"
                || x.DefinitionName == "Main CD to AT"
                || x.DefinitionName == "Dev CD to CI"
                || x.DefinitionName == "Dev CD to AT"
                || x.DefinitionName == "Dev CI CrossDomain.Integration"
                || x.DefinitionName == "Main CI CrossDomain.Integration").ToList());
        }

        private List<BuildTestRun> GetTestResult(Uri buildUri, TfsTeamProjectCollection tfs)
        {
            List<BuildTestRun> lstTestRunDetails = new List<BuildTestRun>();
            var tms = tfs.GetService<ITestManagementService>();

            var testRuns = tms.GetTeamProject("FCT").TestRuns.ByBuild(buildUri);

            foreach (var testRun in testRuns)
            {
                var run = new BuildTestRun
                {
                    Name = testRun.Title,
                    TotalTests = testRun.Statistics.TotalTests,
                    TotalTestsFailed = testRun.Statistics.FailedTests,
                    TotalTestsPassed = testRun.Statistics.PassedTests,
                    TotalTestsInconclusive = testRun.Statistics.InconclusiveTests,
                    TotalTestsPending = testRun.Statistics.PendingTests,
                    TotalTestsInProgress = testRun.Statistics.InProgressTests,
                    TotalTestsCompleted = testRun.Statistics.CompletedTests,
                    FailedTestNameList =
                        new List<string>(testRun.QueryResultsByOutcome(TestOutcome.Failed).Select(x => x.TestCaseTitle))
                };

                lstTestRunDetails.Add(run);
            }

            return lstTestRunDetails;
        }
    }
}

