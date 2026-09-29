using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using TfsBuildRecorder.Helpers;

namespace TfsBuildRecorder.Entities
{
    internal class BuildInformationManager
    {
        private readonly ILogManager _logger = new TextFileLogManager();

        public BuildInformationManager()
        {
            SetTfs();
        }

        private ILogManager Logger
        {
            get { return _logger; }
        }

        public TfsTeamProjectCollection Tfs { get; set; }

        public IBuildServer BuildServer { get; set; }

        public IBuildDetailSpec Spec { get; set; }

        private void SetTfs()
        {
            var tfsCred = CredentialManager.GetTfsCredentials();
            
            //Connect to TFS build server
            string serverName = "https://tfs.sfa.bis.gov.uk/DefaultCollection";
            Uri tfsUri = new Uri(serverName);
            Tfs = new TfsTeamProjectCollection(tfsUri, tfsCred);

            Tfs.Authenticate();

            BuildServer = (IBuildServer)Tfs.GetService(typeof(IBuildServer));

            var buildDefinitons = BuildServer.QueryBuildDefinitions("FCT");
        }

        private List<TfsBuildDetail> GetAllBuilds()
        {
            var builds = BuildServer.QueryBuilds(Spec).Builds;

            Logger.WriteLog("Transforming Builds");

            var buildList = new List<TfsBuildDetail>();

            foreach (var buildDetail in builds)
            {
                var build = new TfsBuildDetail();
                build.DefinitionName = buildDetail.BuildDefinition != null
                    ? buildDetail.BuildDefinition.Name
                    : buildDetail.LabelName.Substring(0, buildDetail.LabelName.LastIndexOf('$'));
                build.FinishTime = buildDetail.FinishTime;
                build.LabelName = buildDetail.LabelName;
                if (buildDetail.BuildDefinition != null)
                {
                    build.LastGoodLabelName = buildDetail.BuildDefinition.LastGoodBuildLabel;
                }
                build.RequestedFor = buildDetail.RequestedFor;
                build.StartTime = buildDetail.StartTime;
                build.Status = buildDetail.Status;
                build.FinishTimeAsString = build.FinishTime.ToString("ddMMMyyyyhhmm");

                buildList.Add(build);
            }

            return buildList;
        }

        public void SetKeyBuildInfo(BuildInformation buildInfo)
        {
            buildInfo.KeyBuildList = new List<TfsBuildDetail>();
            try
            {
                Logger.WriteLog("Fetching key build definitions");

                var buildDefinitons = BuildServer.QueryBuildDefinitions("FCT").Where(x =>
                    x.Name == "Main CD to CI"
                    || x.Name == "Main CD to AT"
                    || x.Name == "Dev CD to CI"
                    || x.Name == "Dev CD to AT"
                    || x.Name == "Dev CI CrossDomain.Integration"
                    || x.Name == "Main CI CrossDomain.Integration").ToList();

                Logger.WriteLog("Got all key build definitions");

                foreach (var definition in buildDefinitons)
                {
                    Logger.WriteLog(string.Format("Fetching builds for {0}",definition.Name));

                    CreateSpecForDefinition(definition);

                    buildInfo.KeyBuildList.AddRange(GetAllBuilds());
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

        private void CreateSpecForDefinition(IBuildDefinition definition)
        {
            //Specify query
            Spec = BuildServer.CreateBuildDetailSpec(definition);
            Spec.MinFinishTime = DateTime.Now.AddDays(int.Parse(ConfigurationManager.AppSettings["MinFinishTime"])); //to get only builds of last 4 weeks
            //Spec.MaxBuildsPerDefinition = int.Parse(ConfigurationManager.AppSettings["MaxBuildsPerDefinition"]); //get only one build per build definintion
            Spec.QueryOrder = BuildQueryOrder.FinishTimeDescending; //get the latest build only
            Spec.QueryOptions = QueryOptions.Definitions;
        }

        public void SetBrokenBuilds(BuildInformation buildInfo)
        {
            var buildlist = GetAllBuilds();
            buildInfo.BrokenBuilds = new List<string>(
                    buildlist.Where(x => x.Status != BuildStatus.Succeeded && x.Status != BuildStatus.InProgress)
                        .Select(y => y.DefinitionName + " by " + y.RequestedFor));
        }

        private List<BuildTestRun> GetTestResult(Uri buildUri, TfsTeamProjectCollection tfs)
        {
            var lstTestRunDetails = new List<BuildTestRun>();
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