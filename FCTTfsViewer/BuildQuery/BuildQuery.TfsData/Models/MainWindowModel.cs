using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Globalization;
    using System.Net;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.Build.Common;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.ProcessConfiguration.Client;
    using Microsoft.TeamFoundation.Server;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using TfsExtensions;
    using TfsRESTApi;
    using Field = Microsoft.TeamFoundation.WorkItemTracking.WebApi.Preview.Models.Field;

    public class MainWindowModel : INotifyPropertyChanged
    {
        private readonly NetworkCredential _tfsAccessCredential;
        public MainWindowModel(NetworkCredential credential)
        {
            _tfsAccessCredential = credential;
        }

        #region properties
        private DateTime _lastRefresh;

        private ObservableCollection<FctBuildDetail> _buildList;
        private int brokenBuildIndex = 0;
        public ObservableCollection<FctBuildDetail> BuildList
        {
            get { return _buildList; }
            set
            {
                _buildList = value;
                OnPropertyChanged("BuildList");
            }
        }
        private ObservableCollection<FctBuildDetail> _keyBuildList;

        public ObservableCollection<FctBuildDetail> KeyBuildList
        {
            get { return _keyBuildList; }
            set
            {
                _keyBuildList = value;
                OnPropertyChanged("KeyBuildList");
            }
        }
        private ObservableCollection<FctBuildDetail> _runningKeyBuildList;

        public ObservableCollection<FctBuildDetail> RunningKeyBuildList
        {
            get { return _runningKeyBuildList; }
            set
            {
                _runningKeyBuildList = value;
                OnPropertyChanged("RunningKeyBuildList");
            }
        }
        private ObservableCollection<FctBurndown> _teamBurnDowns;

        public ObservableCollection<FctBurndown> TeamBurnDowns
        {
            get { return _teamBurnDowns; }
            set
            {
                _teamBurnDowns = value;
                OnPropertyChanged("TeamBurnDowns");
            }
        }

        private ObservableCollection<string> _brokenBuilds;
        public ObservableCollection<string> BrokenBuilds
        {
            get { return _brokenBuilds; }
            set
            {
                _brokenBuilds = value;
                OnPropertyChanged("BrokenBuilds");
            }
        }
        private ObservableCollection<FctTask> _inProgressTasks;
        public ObservableCollection<FctTask> InProgressTasks
        {
            get { return _inProgressTasks; }
            set
            {
                _inProgressTasks = value;
                OnPropertyChanged("InProgressTasks");
            }
        }
        private string _buildText;
        public string BuildText
        {
            get { return _buildText; }
            set
            {
                _buildText = value;
                OnPropertyChanged("BuildText");
            }
        }
        public DateTime LastRefresh
        {
            get { return _lastRefresh; }
            set { _lastRefresh = value; OnPropertyChanged("LastRefresh"); }
        }
        #endregion

        #region Methods
        public void GetTfsDataApi()
        {
            string rootUrl = @"https://tfs.sfa.bis.gov.uk/DefaultCollection/";
            IHttpRequestHeaderFilter filter = new BasicAuthenticationFilter(_tfsAccessCredential);
            var manager = new TfsRESTApiManager(rootUrl, filter,_tfsAccessCredential);
            var defList = manager.GetBuildDefinitions().Result;
            var buildList = manager.GetLatestBuilds(defList.Items.Where(y => y.Id.HasValue).Select(x => x.Id.Value)).Result;
            buildList.Items = buildList.Items.GroupBy(x => x.Definition.Id).Select(y => y.First()).ToList();

            buildList.Items.ForEach(
                b=> 
                {
                    b.TestRuns = manager.GetTestRunsForBuild(b.Id.Value).Result;
                    //b.TestRuns.Items.ForEach(
                    //    tr =>
                    //    {
                    //        tr.TestResults =
                    //            manager.GetTestResultsForRun(tr.Id.Value).Result;

                    //    });
                });
            var keyBuildList = new ObservableCollection<Build>(buildList.Items.Where(x =>
                x.Definition.Name == "Main CD to CI"
                || x.Definition.Name == "Main CD to AT"
                || x.Definition.Name == "Dev CD to DCI"
                || x.Definition.Name == "Dev CD to DAT").ToList());

        }

        public List<FctBuildDetail> GetNewBuildsViaRestApi(TfsTeamProjectCollection tfs, List<string> buildNames = null, bool onlyCompletedBuilds = false)
        {
            string rootUrl = @"https://tfs.sfa.bis.gov.uk/DefaultCollection/";
            IHttpRequestHeaderFilter filter =
                new BasicAuthenticationFilter(_tfsAccessCredential);
            var manager = new TfsRESTApiManager(rootUrl, filter,_tfsAccessCredential);
            var defList = manager.GetBuildDefinitions("build").Result;
            JsonCollection<Build> buildListApi = null;
            if (!onlyCompletedBuilds)
            {
                buildListApi =
                    manager.GetLatestBuilds(defList.Items.Where(y => y.Id.HasValue).Select(x => x.Id.Value)).Result;
            }
            else
            {
                buildListApi =
                    manager.GetLatestCompletedBuilds(defList.Items.Where(y => y.Id.HasValue).Select(x => x.Id.Value))
                        .Result;
            }
            buildListApi.Items = buildListApi.Items.GroupBy(x => x.Definition.Id).Select(y => y.First()).ToList();

            var buildlist = new List<FctBuildDetail>();

            foreach (var buildDetail in buildListApi.Items)
            {
                var build = new FctBuildDetail();
                build.DefinitionName = defList.Items.Single(d => d.Id == buildDetail.Definition.Id).Name;
                if (build.DefinitionName == null)
                {
                    build.DefinitionName = buildDetail.BuildNumber.Substring(0, buildDetail.BuildNumber.LastIndexOf('_'));
                }
                build.FinishTime = buildDetail.FinishTime;
                build.LabelName = buildDetail.Name;
                build.LastGoodLabelName = null;
                build.RequestedFor = buildDetail.RequestedFor.DisplayName;
                build.StartTime = buildDetail.StartTime;
                switch (buildDetail.Status)
                {
                    case "inProgress":
                        build.Status = BuildStatus.InProgress;
                        break;
                }
                ;
                switch (buildDetail.Result)
                {
                    case "failed":
                        build.Status = BuildStatus.Failed;
                        break;
                    case "succeeded":
                        build.Status = BuildStatus.Succeeded;
                        break;
                    case "stopped":
                        build.Status = BuildStatus.Stopped;
                        break;
                }
                ;
                build.TestStatus = BuildPhaseStatus.Unknown;

                if (buildNames == null || buildNames.Contains(build.DefinitionName))
                {
                    build.TestRunList =
                        new ObservableCollection<FctTestRun>(GetTestResult(new Uri(buildDetail.Uri), tfs));


                    //var buildTestRuns = manager.GetTestRunsForBuild(buildDetail.Id.Value).Result;
                    //buildTestRuns.Items.ForEach(
                    //    tr =>
                    //    {
                    //        tr.TestResults =
                    //            manager.GetTestResultsForRun(tr.Id.Value).Result;

                    //    });

                    if (build.TestRunList.Any(x => x.TotalTestsFailed > 0))
                    {
                        build.TestStatus = BuildPhaseStatus.Failed;
                    }
                    if (build.TestRunList.All(x => x.TotalTestsPassed == x.TotalTests))
                    {
                        build.TestStatus = BuildPhaseStatus.Succeeded;
                    }
                    build.Warnings = 0;
                    //buildDetail.Information.GetNodesByType(InformationTypes.BuildWarning, false).Count();

                    buildlist.Add(build);
                }
            }
            return buildlist;
        }

        public void GetTfsData()
        {
            // Auth with UserName & Password (Microsoft Acc):
            BasicAuthCredential basicCred = new BasicAuthCredential(_tfsAccessCredential);
            TfsClientCredentials tfsCred = new TfsClientCredentials(basicCred);
            tfsCred.AllowInteractive = false;
            //

            //Connect to TFS build server
            string serverName = "https://tfs.sfa.bis.gov.uk/DefaultCollection";
            Uri tfsUri = new Uri(serverName);
            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(tfsUri, _tfsAccessCredential); //<==using network credentials directly

            tfs.Authenticate();
            var buildlist = GetXamlBuilds(tfs);
            buildlist.AddRange(GetNewBuildsViaRestApi(tfs));
            BuildList = new ObservableCollection<FctBuildDetail>(buildlist.OrderBy(x=>x.DefinitionName));
            RunningKeyBuildList =
                new ObservableCollection<FctBuildDetail>(buildlist.Where(x => (x.DefinitionName == "Main CD to CI"
                                                                               || x.DefinitionName == "Main CD to AT"
                                                                               || x.DefinitionName == "Dev CD to DCI"
                                                                               || x.DefinitionName == "Dev CD to DAT") 
                                                                               && x.Status == BuildStatus.InProgress));
            BrokenBuilds = new ObservableCollection<string>(buildlist.Where(x => x.Status != BuildStatus.Succeeded && x.Status != BuildStatus.InProgress).Select(y => y.DefinitionName + " by " + y.RequestedFor));

            var keyBuildList = GetNewBuildsViaRestApi(tfs, new List<string>() {"Main CD to CI", "Main CD to AT", "Dev CD to DCI", "Dev CD to DAT"}, true);
            KeyBuildList = new ObservableCollection<FctBuildDetail>(keyBuildList.ToList().OrderBy(y => y.DefinitionName));
            LastRefresh = DateTime.Now;

            List<FctBurndown> burndowns = GetAllTeamBurndownData(tfs,
                new List<string>() {"FCT\\Dev", "FCT\\Ops", "FCT\\Project 1", "FCT\\Project 2" });
            TeamBurnDowns = new ObservableCollection<FctBurndown>(burndowns);
            TeamBurnDowns.Add(FctBurndown.CombineBurndowns(TeamBurnDowns.ToList()));

            InProgressTasks = new ObservableCollection<FctTask>(GetInProgressTaskData(tfs).OrderBy(x=>x.FirstInProgressDate));
        }

        private List<FctBuildDetail> GetXamlBuilds(TfsTeamProjectCollection tfs,List<string> buildNames=null,bool onlyCompletedBuilds=false)
        {
            var buildlist = new List<FctBuildDetail>();
            var buildServer = (IBuildServer) tfs.GetService(typeof (IBuildServer));
            var buildDefinitionList = new List<IBuildDefinition>(buildServer.QueryBuildDefinitions("FCT"));

            //Specify query
            IBuildDetailSpec spec = buildServer.CreateBuildDetailSpec("*");
            //Microsoft.TeamFoundation.Build.Common.InformationTypes.BuildWarning
            spec.InformationTypes =
                new List<string> {InformationTypes.BuildWarning, InformationTypes.AssociatedChangeset}.ToArray();
                // for speed improvement
            spec.MinFinishTime = DateTime.Now.AddDays(-21); //to get only builds of last 3 weeks
            spec.MaxBuildsPerDefinition = 1; //get only one build per build definintion
            spec.QueryOrder = BuildQueryOrder.FinishTimeDescending; //get the latest build only
            spec.QueryOptions = QueryOptions.All;
            if (onlyCompletedBuilds)
            {
                spec.Status = BuildStatus.Failed | BuildStatus.PartiallySucceeded | BuildStatus.Stopped |
                              BuildStatus.Succeeded;
            }
            var builds = buildServer.QueryBuilds(spec).Builds;

            foreach (var buildDetail in builds)
            {
                var build = new FctBuildDetail();
                build.DefinitionName = buildDetail.BuildDefinition != null
                    ? buildDetail.BuildDefinition.Name
                    : (buildDetail.LabelName != null)
                        ? buildDetail.LabelName.Substring(0, buildDetail.LabelName.LastIndexOf('$'))
                        : buildDetail.BuildNumber.Substring(0, buildDetail.BuildNumber.LastIndexOf('_'));
                build.FinishTime = buildDetail.FinishTime;
                build.LabelName = buildDetail.LabelName;
                build.LastGoodLabelName = buildDetail.BuildDefinition != null
                    ? buildDetail.BuildDefinition.LastGoodBuildLabel
                    : null;
                build.RequestedFor = buildDetail.RequestedFor;
                build.StartTime = buildDetail.StartTime;
                build.Status = buildDetail.Status;
                build.TestStatus = buildDetail.TestStatus;
                if (buildNames == null || buildNames.Contains(build.DefinitionName))
                {
                    build.TestRunList = new ObservableCollection<FctTestRun>(GetTestResult(buildDetail.Uri, tfs));
                    build.Warnings =
                        buildDetail.Information.GetNodesByType(InformationTypes.BuildWarning, false).Count();

                    buildlist.Add(build);
                }
            }
            return buildlist;
        }

        private static List<FctBurndown> GetAllTeamBurndownData(TfsTeamProjectCollection tfs, List<string> areaPaths)
        {
            // Retrieve the common process configuration settings.
            // The work item fields, states and types are stored here.
            ProjectProcessConfigurationService pps = tfs.GetService<ProjectProcessConfigurationService>();
            WorkItemStore wiStore = new WorkItemStore(tfs);
            Project project = wiStore.Projects["FCT"];

            string projectUri = project.Uri.AbsoluteUri;

            var teamSettings = GetTeamSettings(tfs, projectUri);

            DateTime startDate, endDate;
            var isSuccess = GetIterationDates(tfs, project.Uri.ToString(), teamSettings.CurrentIterationPath,
                out startDate,
                out endDate);

            string rwField;
            string efField;
            string teamField;
            var taskQueryText = GetTaskQueryText(tfs, teamSettings, pps, project, areaPaths, out rwField,out teamField);
            var storyQueryText = GetStoryQueryText(tfs, teamSettings, pps, project, areaPaths, out efField);

            var burndowns = new List<FctBurndown>();
            areaPaths.ForEach(
                x =>
                {
                    burndowns.Add(new FctBurndown()
                    {
                        DataPoints = new ObservableCollection<BurnDownDataPoint>(),
                        Iteration = teamSettings.CurrentIterationPath,
                        Team = x
                    });
                });
            
            var data = GetDataPoints(burndowns,startDate, endDate, taskQueryText, storyQueryText, wiStore, rwField, efField, teamField);

            return burndowns;
        }

        private List<FctTask> GetInProgressTaskData(TfsTeamProjectCollection tfs)
        {
            // Retrieve the common process configuration settings.
            // The work item fields, states and types are stored here.
            ProjectProcessConfigurationService pps = tfs.GetService<ProjectProcessConfigurationService>();
            WorkItemStore wiStore = new WorkItemStore(tfs);
            Project project = wiStore.Projects["FCT"];

            string projectUri = project.Uri.AbsoluteUri;

            var teamSettings = GetTeamSettings(tfs, projectUri);

            DateTime startDate, endDate;
            var isSuccess = GetIterationDates(tfs, project.Uri.ToString(), teamSettings.CurrentIterationPath,
                out startDate,
                out endDate);

            string rwField;
            string efField;
            var taskQueryText = GetTaskInProgressQueryText(tfs, teamSettings, pps, project);
            return  GetLingeringTasks(taskQueryText, wiStore);

        }

        private List<FctTestRun> GetTestResult(Uri buildUri, TfsTeamProjectCollection tfs)
        {
            List<FctTestRun> lstTestRunDetails = new List<FctTestRun>();
            var tms = tfs.GetService<ITestManagementService>();

            var testRuns = tms.GetTeamProject("FCT").TestRuns.ByBuild(buildUri);

            foreach (var testRun in testRuns)
            {
                var run = new FctTestRun();
                run.Name = testRun.Title;
                run.TotalTests = testRun.Statistics.TotalTests;
                run.TotalTestsFailed = testRun.Statistics.FailedTests;
                run.TotalTestsPassed = testRun.Statistics.PassedTests;
                run.TotalTestsInconclusive = testRun.Statistics.InconclusiveTests;
                run.TotalTestsPending = testRun.Statistics.PendingTests;
                run.TotalTestsInProgress = testRun.Statistics.InProgressTests;
                run.TotalTestsCompleted = testRun.Statistics.CompletedTests;
                run.FailedTestNameList = new ObservableCollection<string>(testRun.QueryResultsByOutcome(TestOutcome.Failed).Select(x => x.TestCaseTitle));
                run.FailedTestList =
                    new ObservableCollection<FctFailedTest>(
                        testRun.QueryResultsByOutcome(TestOutcome.Failed).Select(x => new FctFailedTest()
                        {
                            Name = x.TestCaseTitle,
                            ErrorMessage =x.ErrorMessage,
                            TestRunName =testRun.Title,
                            BuildName =testRun.BuildNumber
                        }));

                lstTestRunDetails.Add(run);
            }

            return lstTestRunDetails;
        }

        static string GetTaskQueryText(TfsTeamProjectCollection tfs, TeamSettings teamSettings, ProjectProcessConfigurationService pps, Project project, List<string> areaPaths, out string remainingWorkField,out string teamField)
        {


            CommonProjectConfiguration commonCfg = pps.GetCommonConfiguration(project.Uri.AbsoluteUri);

            // The type fields tell us what fields are the RemainingWork and Team fields.
            TypeField[] fields = commonCfg.TypeFields;

            // The name of the work item field that represents the remaining work.
            remainingWorkField = fields.FirstOrDefault(fld => fld.Type == FieldTypeEnum.RemainingWork).Name;

            // The work item fields that specified which team the work item belongs to.
            teamField = fields.FirstOrDefault(fld => fld.Type == FieldTypeEnum.Team).Name;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT [System.Id],[{1}], [{0}] ", remainingWorkField, teamField);
            sb.Append("FROM WorkItems WHERE (");


            string iterationPath = teamSettings.CurrentIterationPath;

            const string or = " OR ";
            List<string> conditions = new List<string>();

            // Condition #1: team scopes / work areas.
            var grouped = teamSettings.TeamFieldValues.GroupBy(tfv => tfv.IncludeChildren);
            StringBuilder scopes = new StringBuilder();

            foreach (var areaPath in areaPaths)
            {
                scopes.AppendFormat("[{0}] UNDER '{1}'{2}", teamField, areaPath, or);
            }
            

            // Make sure that the condition is complete.
            if (scopes.ToString().EndsWith(or))
                scopes.Remove(scopes.Length - or.Length, or.Length);

            conditions.Add(scopes.ToString());

            // Condition #2: the iteration path.
            conditions.Add(string.Format("[System.IterationPath] = '{0}'", iterationPath));

            // Condition #3: task work item types.
            string taskWorkItemsCategoryName = commonCfg.TaskWorkItems.CategoryName;
            Category taskCategory = project.Categories.FirstOrDefault(c => c.ReferenceName.Equals(taskWorkItemsCategoryName));
            if (taskCategory != null && taskCategory.WorkItemTypes.Any())
            {
                var joinedTasks = string.Join("', '", taskCategory.WorkItemTypes.Select(wit => wit.Name));
                conditions.Add(string.Format("[System.WorkItemType] IN ('{0}')", joinedTasks));
            }

            var states = new[] { StateTypeEnum.Proposed, StateTypeEnum.InProgress };

            // Condition #4: work items that are not done.
            var inProgressStates = commonCfg.TaskWorkItems.States.Where(s => states.Contains(s.Type)).Select(s => s.Value);
            var joinedStates = string.Join("', '", inProgressStates);
            conditions.Add(string.Format("[System.State] IN ('{0}')", joinedStates));

            // Condition #5: the remaining work.
            conditions.Add(string.Format("[{0}] >= 0", remainingWorkField));

            string allConditions = string.Join(") AND (", conditions);
            sb.AppendFormat("({0}))", allConditions);

            return sb.ToString();


        }


        static string GetStoryQueryText(TfsTeamProjectCollection tfs, TeamSettings teamSettings, ProjectProcessConfigurationService pps, Project project, List<string> areaPaths, out string effortField)
        {
            CommonProjectConfiguration commonCfg = pps.GetCommonConfiguration(project.Uri.AbsoluteUri);

            // The type fields tell us what fields are the RemainingWork and Team fields.
            TypeField[] fields = commonCfg.TypeFields;

            // The name of the work item field that represents the remaining work.
            effortField = fields.FirstOrDefault(fld => fld.Type == FieldTypeEnum.Effort).Name;

            // The work item fields that specified which team the work item belongs to.
            string teamField = fields.FirstOrDefault(fld => fld.Type == FieldTypeEnum.Team).Name;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT [System.Id], [{1}], [{0}] ", effortField, teamField);
            sb.Append("FROM WorkItems WHERE (");


            string iterationPath = teamSettings.CurrentIterationPath;

            const string or = " OR ";
            List<string> conditions = new List<string>();

            // Condition #1: team scopes / work areas.
            var grouped = teamSettings.TeamFieldValues.GroupBy(tfv => tfv.IncludeChildren);
            StringBuilder scopes = new StringBuilder();

            foreach (var areaPath in areaPaths)
            {
                scopes.AppendFormat("[{0}] UNDER '{1}'{2}", teamField, areaPath, or);
            }


            // Make sure that the condition is complete.
            if (scopes.ToString().EndsWith(or))
                scopes.Remove(scopes.Length - or.Length, or.Length);

            conditions.Add(scopes.ToString());

            // Condition #2: the iteration path.
            conditions.Add(string.Format("[System.IterationPath] = '{0}'", iterationPath));

            // Condition #3: task work item types.
            string requirementWorkItemsCategoryName = commonCfg.RequirementWorkItems.CategoryName;
            Category requiresentsCategory = project.Categories.FirstOrDefault(c => c.ReferenceName.Equals(requirementWorkItemsCategoryName));
            if (requiresentsCategory != null && requiresentsCategory.WorkItemTypes.Any())
            {
                var joinedTasks = string.Join("', '", requiresentsCategory.WorkItemTypes.Select(wit => wit.Name));
                conditions.Add(string.Format("[System.WorkItemType] IN ('{0}')", joinedTasks));
            }

            var states = new[] { StateTypeEnum.InProgress };

            // Condition #4: work items that are not done.
            var inProgressStates = commonCfg.RequirementWorkItems.States.Where(s => states.Contains(s.Type)).Select(s => s.Value);
            var joinedStates = string.Join("', '", inProgressStates);
            conditions.Add(string.Format("[System.State] IN ('{0}')", joinedStates));

            // Condition #5: the remaining work.
            conditions.Add(string.Format("[{0}] >= 0", effortField));

            string allConditions = string.Join(") AND (", conditions);
            sb.AppendFormat("({0}))", allConditions);

            return sb.ToString();


        }

        static string GetTaskInProgressQueryText(TfsTeamProjectCollection tfs, TeamSettings teamSettings, ProjectProcessConfigurationService pps, Project project)
        {

            CommonProjectConfiguration commonCfg = pps.GetCommonConfiguration(project.Uri.AbsoluteUri);


            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT [System.Id],[System.AssignedTo] ");
            sb.Append("FROM WorkItems WHERE (");


            string iterationPath = teamSettings.CurrentIterationPath;

            List<string> conditions = new List<string>();

            // Condition #1: the iteration path.
            conditions.Add($"[System.IterationPath] = '{iterationPath}'");

            // Condition #2: task work item types.
            string taskWorkItemsCategoryName = commonCfg.TaskWorkItems.CategoryName;
            Category taskCategory = project.Categories.FirstOrDefault(c => c.ReferenceName.Equals(taskWorkItemsCategoryName));
            if (taskCategory != null && taskCategory.WorkItemTypes.Any())
            {
                var joinedTasks = string.Join("', '", taskCategory.WorkItemTypes.Select(wit => wit.Name));
                conditions.Add(string.Format("[System.WorkItemType] IN ('{0}')", joinedTasks));
            }

            var states = new[] { StateTypeEnum.Proposed, StateTypeEnum.InProgress };

            // Condition #3: work items that are not done.
            var inProgressStates = commonCfg.TaskWorkItems.States.Where(s => states.Contains(s.Type)).Select(s => s.Value);
            var joinedStates = string.Join("', '", inProgressStates);
            conditions.Add(string.Format("[System.State] IN ('{0}')", joinedStates));

            // Condition #4: work items that were ever in progress
            conditions.Add(string.Format("[System.State] EVER '{0}'", commonCfg.TaskWorkItems.States.Single(s=>s.Type==StateTypeEnum.InProgress).Value));

            
            string allConditions = string.Join(") AND (", conditions);
            sb.AppendFormat("({0}))", allConditions);

            return sb.ToString();


        }


        private static TeamSettings GetTeamSettings(TfsTeamProjectCollection tfs, string projectUri)
        {
            // Retrieve the default team for the team project.
            TfsTeamService tfsTeamService = tfs.GetService<TfsTeamService>();
            Guid defaultTeamId = tfsTeamService.GetDefaultTeamId(projectUri);

            // Retrieve the configuration settings for the team.
            TeamSettingsConfigurationService cfg = tfs.GetService<TeamSettingsConfigurationService>();
            var configs = cfg.GetTeamConfigurationsForUser(new[] { projectUri });
            TeamSettings teamSettings = configs.FirstOrDefault(c => c.TeamId == defaultTeamId).TeamSettings;
            return teamSettings;
        }

        private static bool GetIterationDates(TfsTeamProjectCollection tfs, string projectUri,
                string iterationPath, out DateTime startDate, out DateTime finishDate)
        {
            ICommonStructureService4 css = tfs.GetService<ICommonStructureService4>();
            startDate = finishDate = DateTime.MinValue;


            var schedule = css.GetIterationDates(projectUri);
            var sch = schedule.FirstOrDefault(s => s.Path.Equals(iterationPath));

            if (sch != null)
            {
                if (sch.StartDate.HasValue && sch.EndDate.HasValue)
                {
                    startDate = sch.StartDate.Value;
                    finishDate = sch.EndDate.Value;
                    return true;
                }
            }

            return false;
        }

        public static List<FctBurndown> GetDataPoints(List<FctBurndown> burndowns,DateTime startDate, DateTime finishDate, string taskqueryText, string storyQueryText, WorkItemStore wiStore, string remainingWorkField, string effortField,string teamField)
        {
            DateTime today = DateTime.Today;
            //List<BurnDownDataPoint> dataPoints = new List<BurnDownDataPoint>();
            
            var ci = CultureInfo.CurrentCulture;
            int index = 0;
            for (DateTime date = startDate; date <= finishDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                //double? work = null;
                //double? storyWork = null;
                Dictionary<string, double?> teamWork=new Dictionary<string,double?>();
                Dictionary<string, double?> storyTeamWork=new Dictionary<string,double?>();

                if (date <= today)
                {
                    string asof = date.AddDays(1).AddMilliseconds(-1).ToString(ci);
                    string fullTaskQuery = string.Format("{0} ASOF '{1}'", taskqueryText, asof);
                    string fullStoryQuery = string.Format("{0} ASOF '{1}'", storyQueryText, asof);

                    IEnumerable<WorkItem> items = wiStore.Query(fullTaskQuery).
                        OfType<WorkItem>().Where(wi => wi.Fields.Contains(remainingWorkField)).ToList();
                    IEnumerable<WorkItem> storyItems = wiStore.Query(fullStoryQuery).
                        OfType<WorkItem>().Where(wi => wi.Fields.Contains(effortField)).ToList();

                   // work = items.Sum(wi => wi.Fields[remainingWorkField].Value as double?);
                   // storyWork = storyItems.Sum(wi => wi.Fields[effortField].Value as double?);

                    foreach (var team in burndowns.Select(x => x.Team))
                    {
                        teamWork.Add(team,
                            items.Where(i => (string) i.Fields[teamField].Value == team)
                                .Sum(wi => wi.Fields[remainingWorkField].Value as double?));
                        storyTeamWork.Add(team,
                            storyItems.Where(i => (string) i.Fields[teamField].Value == team)
                                .Sum(wi => wi.Fields[effortField].Value as double?));
                    }
                }
                else
                {
                    foreach (var team in burndowns.Select(x => x.Team))
                    {
                        teamWork.Add(team, null);
                        storyTeamWork.Add(team, null);

                    }
                }
                burndowns.ForEach(
                    (x) =>
                    {
                        x.DataPoints.Add(new BurnDownDataPoint
                        {
                            Index = index,
                            Date = date,
                            RemainingWorkHours = teamWork[x.Team],
                            RemainingWorkPoints = storyTeamWork[x.Team],
                            IdealTrendHours =
                                date == startDate ? teamWork[x.Team] : date == finishDate ? 0 : (double?) null,
                            IdealTrendPoints =
                                date == startDate ? storyTeamWork[x.Team] : date == finishDate ? 0 : (double?) null,

                        });
                    });
                
                index++;
            }

            return burndowns;
        }

        public void SetBuildText()
        {
            brokenBuildIndex++;
            if (BrokenBuilds.Count > 0)
            {
                if (brokenBuildIndex > BrokenBuilds.Count - 1)
                {
                    brokenBuildIndex = 0;
                }
                BuildText = BrokenBuilds[brokenBuildIndex];
            }
            else
            {
                brokenBuildIndex = 0;
                BuildText = "";
            }
        }


        public static List<FctTask> GetLingeringTasks(string taskqueryText, WorkItemStore wiStore)
        {
            var tasks = new List<FctTask>();
            var ci = CultureInfo.CurrentCulture;
            var items = wiStore.Query(taskqueryText).
                        OfType<WorkItem>().ToList();
            items.ForEach(
                t =>
                {
                    
                    var dataTable = new DataTable();

                    foreach (Microsoft.TeamFoundation.WorkItemTracking.Client.Field field in t.Fields)
                    {
                        dataTable.Columns.Add(field.Name);
                    }

                    // Loop through the work item revisions
                    foreach (Revision revision in t.Revisions)
                    {
                        // Get values for the work item fields for each revision
                        var row = dataTable.NewRow();
                        foreach (Microsoft.TeamFoundation.WorkItemTracking.Client.Field field in t.Fields)
                        {
                            row[field.Name] = revision.Fields[field.Name].Value;
                        }
                        dataTable.Rows.Add(row);
                    }
                    var timeWentInProgress = new DateTime();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                        var currentRow = dataTable.Rows[i];
                        if (currentRow.Field<string>("State") == "In Progress")
                        {
                            timeWentInProgress = DateTime.Parse(currentRow.Field<string>("Changed Date"));
                            break;
                        }
                        
                    }
                    var storyLink =
                        t.WorkItemLinks.OfType<WorkItemLink>().SingleOrDefault(l => l.LinkTypeEnd.Name == "Parent");
                    var task = new FctTask()
                    {
                        FirstInProgressDate = timeWentInProgress,
                        Name = t.Title,
                        Assigned = (string)t.Fields["Assigned To"].Value,
                        StoryName = storyLink != null ? wiStore.GetWorkItem(storyLink.TargetId).Title:""

                    };
                    tasks.Add(task);
                });      
            

            return tasks;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
        
    }
}
