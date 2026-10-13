using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using ReleaseBranchUtilityLib;

namespace PlayWithTheApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string repoName = "FCS";

            (var connection, var project) = ReleaseBranchAdder.GetConnectionAndProject("https://dev.azure.com/sfa-fcs", "FCT");

            GitHttpClient gitClient = connection.GetClient<GitHttpClient>();

            var refs = gitClient.GetRefsAsync(project: project.Name, repositoryId: repoName, "tags").Result;

            string releaseNumberGroup = "releaseNumber";
            string releaseLetterGroup = "releaseLetter";
            Regex tagRegex = new Regex($"^refs/tags/[Rr](?<{releaseNumberGroup}>[0-9]+)(?<{releaseLetterGroup}>[a-z]?)$");
            var mostRecentTag = refs
                .Select(r => tagRegex.Match(r.Name))
                .Where(m => m.Success)
                .OrderByDescending(m => m.Value)
                .FirstOrDefault();

            int? currentReleaseNumber = null;
            char? nextReleaseLetter =  null;
            if (mostRecentTag != null && mostRecentTag.Groups[releaseNumberGroup].Success && int.TryParse(mostRecentTag.Groups[releaseNumberGroup].Value, out int releaseNumber))
            {
                currentReleaseNumber = releaseNumber;

                if (mostRecentTag.Groups[releaseLetterGroup].Success)
                {
                    nextReleaseLetter = mostRecentTag.Groups[releaseLetterGroup].Value[0];
                    if (nextReleaseLetter < 'z')
                        nextReleaseLetter++;
                    else
                        nextReleaseLetter = null;
                }
                else
                {
                    nextReleaseLetter = 'a';
                }
            }
        }
    }
}
