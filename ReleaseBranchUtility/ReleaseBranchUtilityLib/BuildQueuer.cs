namespace ReleaseBranchUtilityLib
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.VisualStudio.Services.WebApi;

    public static class BuildQueuer
    {
        /// <summary>
        /// this will queue the unit test builds and Fcs Core build (unit and integration)
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="connection"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool QueueCIBuilds(Guid projectId, VssConnection connection, Action<string> log)
        {
            BuildHttpClient buildClient = connection.GetClient<BuildHttpClient>();
            var definitions = buildClient.GetDefinitionsAsync(projectId).Result;
            Regex justCIMatchingRegex = new Regex(@"^RB[0-9]{3}\sCI\s");
            var ciDefinitions = definitions.Where(d => justCIMatchingRegex.Match(d.Name).Success)
                .ToList();

            // also we want to run the FcsCore build
            var fscCore = definitions.Single(d => new Regex(@"^RB[0-9]{3}\sCD\sto\sCI\s-\sFCS.Core").Match(d.Name).Success);
            ciDefinitions.Add(fscCore);
            ciDefinitions.ForEach(b =>
            {
                log($"Queueing a build for: {b.Name}");
                try
                {
                    buildClient.QueueBuildAsync(new Build
                    {
                        Definition = new DefinitionReference
                        {
                            Id = b.Id
                        },
                        Project = b.Project
                    }).Wait();
                }
                catch (Exception ex)
                {
                    log($"Failed to queue build for: {b.Name}. Error: {ex.Message}");
                }
            });

            return true;
        }
    }
}
