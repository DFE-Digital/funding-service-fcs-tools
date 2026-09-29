using BuildQuery.TfsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildQuery.Web.Models
{
    public class MainModelManager : IMainModelManager
    {
        private MainWindowModel _mainModelWindow = new MainWindowModel();
        private MainModel _mainModel;
        private Timer _timer;

        private object _sync = new object();

        public MainModel MainModel
        {
            get
            {
                return ActionWithLock("Get");
            }

            set
            {
                _mainModel = value;
            }
        }

        public MainModelManager()
        {
            TimerCallback cb = new TimerCallback(GetAll);
            _timer = new Timer(cb, null, 0, 60000);

        }

        private MainModel ActionWithLock(string method)
        {
            MainModel mainModel = null;
            lock (_sync)
            {
                switch (method)
                {
                    case "Update":
                        UpdateAll();
                        break;
                    case "Get":
                        mainModel = GetMainModel();
                        break;
                }               
            }
            return mainModel;
        }
        private void GetAll(object state)
        {
            //_mainModelWindow.GetTfsDataApi();//<--under development: replace following line with TFS REST API
            _mainModelWindow.GetTfsData();
            ActionWithLock("Update");
        }
        private MainModel GetMainModel()
        {
            return _mainModel;
        }
        private void UpdateAll()
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

            _mainModel = mainModel;

        }
    }
}
