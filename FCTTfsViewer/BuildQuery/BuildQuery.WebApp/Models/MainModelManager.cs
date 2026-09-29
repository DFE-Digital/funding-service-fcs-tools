namespace BuildQuery.WebApp.Models
{
    using System.Configuration;
    using TfsData.Models;
    using System.Threading;
    using System.Linq;
    using System.Net;

    public class MainModelManager : IMainModelManager
    {
        private MainWindowModel _mainModelWindow;
        private MainModel _mainModel;
        private Timer _timer;
        private object _sync = new object();

        public MainModelManager()
        {
            _mainModelWindow = new MainWindowModel(new NetworkCredential(
                ConfigurationManager.AppSettings["tfsUsername"], 
                ConfigurationManager.AppSettings["tfsPassword"], 
                ConfigurationManager.AppSettings["tfsDomain"])
            );
            var cb = new TimerCallback(GetAll);
            _timer = new Timer(cb, null, 0, 60000);
        }

        public MainModel MainModel
        {
            get
            {
                lock (_sync ) { return _mainModel;}
                
            }
            private set
            {
                lock (_sync) { _mainModel = value;}
            }
        }
        
        private void GetAll(object state)
        {
            //_mainModelWindow.GetTfsDataApi();//<--under development: replace following line with TFS REST API
            _mainModelWindow.GetTfsData();
            MainModel = UpdateAll();
        }
        
        private MainModel UpdateAll()
        {
            var mainModel = new MainModel();
            mainModel.BrokenBuilds = _mainModelWindow.BrokenBuilds.AsEnumerable();

            mainModel.BuildList = _mainModelWindow.BuildList.Select(
                bd => new FctBuildDetail()
                {
                    DefinitionName = bd.DefinitionName,
                    FinishTime = bd.FinishTime,
                    LabelName = bd.LabelName,
                    LastGoodLabelName = bd.LastGoodLabelName,
                    RequestedFor = bd.RequestedFor,
                    StartTime = bd.StartTime,
                    Status = bd.Status.ToString(),
                    TestStatus = bd.TestStatus.ToString(),
                    Warnings = bd.Warnings,
                    TestRunList = bd.TestRunList.Select(
                        tr => new FctTestRun()
                        {
                            FailedTestNameList = tr.FailedTestNameList,
                            FailedTestList = tr.FailedTestList.Select(
                                ft => new FctFailedTest()
                                {
                                    ErrorMessage = ft.ErrorMessage,
                                    Name = ft.Name,
                                    BuildName = bd.DefinitionName,
                                    TestRunName = tr.Name
                                }),
                            Name = tr.Name,
                            TotalTests = tr.TotalTests,
                            TotalTestsCompleted = tr.TotalTestsCompleted,
                            TotalTestsFailed = tr.TotalTestsFailed,
                            TotalTestsInconclusive = tr.TotalTestsInconclusive,
                            TotalTestsInProgress = tr.TotalTestsInProgress,
                            TotalTestsPassed = tr.TotalTestsPassed,
                            TotalTestsPending = tr.TotalTestsPending
                        }
                    )
                }

        );

            mainModel.BuildText = _mainModelWindow.BuildText;

            mainModel.KeyBuildList = _mainModelWindow.KeyBuildList.Select(
                bd => new FctBuildDetail()
                {
                    DefinitionName = bd.DefinitionName,
                    FinishTime = bd.FinishTime,
                    LabelName = bd.LabelName,
                    LastGoodLabelName = bd.LastGoodLabelName,
                    RequestedFor = bd.RequestedFor,
                    StartTime = bd.StartTime,
                    Status = bd.Status.ToString(),
                    TestStatus = bd.TestStatus.ToString(),
                    Warnings = bd.Warnings,
                    TestRunList = bd.TestRunList.Select(
                        tr => new FctTestRun()
                        {
                            FailedTestNameList = tr.FailedTestNameList,
                            FailedTestList = tr.FailedTestList.Select(
                                ft => new FctFailedTest()
                                {
                                    ErrorMessage = ft.ErrorMessage,
                                    Name = ft.Name,
                                    BuildName = bd.DefinitionName,
                                    TestRunName = tr.Name
                                }),
                            Name = tr.Name,
                            TotalTests = tr.TotalTests,
                            TotalTestsCompleted = tr.TotalTestsCompleted,
                            TotalTestsFailed = tr.TotalTestsFailed,
                            TotalTestsInconclusive = tr.TotalTestsInconclusive,
                            TotalTestsInProgress = tr.TotalTestsInProgress,
                            TotalTestsPassed = tr.TotalTestsPassed,
                            TotalTestsPending = tr.TotalTestsPending
                        }
                    )
                }
            );
            mainModel.RunningKeyBuildList = _mainModelWindow.RunningKeyBuildList.Select(
               bd => new FctBuildDetail()
               {
                   DefinitionName = bd.DefinitionName,
                   FinishTime = bd.FinishTime,
                   LabelName = bd.LabelName,
                   LastGoodLabelName = bd.LastGoodLabelName,
                   RequestedFor = bd.RequestedFor,
                   StartTime = bd.StartTime,
                   Status = bd.Status.ToString(),
                   TestStatus = bd.TestStatus.ToString(),
                   Warnings = bd.Warnings,
                   TestRunList = bd.TestRunList.Select(
                       tr => new FctTestRun()
                       {
                           FailedTestNameList = tr.FailedTestNameList,
                           FailedTestList = tr.FailedTestList.Select(
                                ft => new FctFailedTest()
                                {
                                    ErrorMessage = ft.ErrorMessage,
                                    Name = ft.Name,
                                    BuildName = bd.DefinitionName,
                                    TestRunName = tr.Name
                                }),
                           Name = tr.Name,
                           TotalTests = tr.TotalTests,
                           TotalTestsCompleted = tr.TotalTestsCompleted,
                           TotalTestsFailed = tr.TotalTestsFailed,
                           TotalTestsInconclusive = tr.TotalTestsInconclusive,
                           TotalTestsInProgress = tr.TotalTestsInProgress,
                           TotalTestsPassed = tr.TotalTestsPassed,
                           TotalTestsPending = tr.TotalTestsPending
                       }
                   )
               }
           );
            mainModel.InProgressTasks = _mainModelWindow.InProgressTasks.Select(
                ipt => new FctTask()
                {
                    Assigned = ipt.Assigned,
                    FirstInProgressDate = ipt.FirstInProgressDate,
                    Name = ipt.Name,
                    StoryName = ipt.StoryName
                }
                );
            mainModel.LastRefresh = _mainModelWindow.LastRefresh;

            mainModel.TeamBurnDowns = _mainModelWindow.TeamBurnDowns.Select(
                t => new FctBurndown()
                {
                    Iteration = t.Iteration,
                    Team = t.Team,
                    DataPoints = t.DataPoints.Select(
                        dp => new BurnDownDataPoint()
                        {
                            ActualTrendHours = dp.ActualTrendHours,
                            ActualTrendPoints = dp.ActualTrendPoints,
                            Date = dp.Date,
                            IdealTrendHours = dp.IdealTrendHours,
                            IdealTrendPoints = dp.IdealTrendPoints,
                            Index = dp.Index,
                            RemainingWorkHours = dp.RemainingWorkHours,
                            RemainingWorkPoints = dp.RemainingWorkPoints
                        })
                }
            );

            return mainModel;

        }
    }
}
