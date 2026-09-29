using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Microsoft.TeamFoundation.Build.Client;

    public class FctBuildDetail : INotifyPropertyChanged
    {
        private BuildStatus _status;

        public BuildStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
        private BuildPhaseStatus _testStatus;

        public BuildPhaseStatus TestStatus
        {
            get { return _testStatus; }
            set
            {
                _testStatus = value;
                OnPropertyChanged("TestStatus");
            }
        }

        private string _definitionName;

        public string DefinitionName
        {
            get { return _definitionName; }
            set
            {
                _definitionName = value;
                OnPropertyChanged("DefinitionName");
            }
        }

        private int _warnings;

        public int Warnings
        {
            get { return _warnings; }
            set
            {
                _warnings = value;
                OnPropertyChanged("Warnings");
            }
        }

        private string _requestedFor;

        public string RequestedFor
        {
            get { return _requestedFor; }
            set
            {
                _requestedFor = value;
                OnPropertyChanged("RequestedFor");
            }
        }

        private string _labelName;

        public string LabelName
        {
            get { return _labelName; }
            set
            {
                _labelName = value;
                OnPropertyChanged("LabelName");
            }
        }
        private string _lastGoodLabelName;

        public string LastGoodLabelName
        {
            get { return _lastGoodLabelName; }
            set
            {
                _lastGoodLabelName = value;
                OnPropertyChanged("LastGoodLabelName");
            }
        }
        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        private DateTime _finishTime;

        public DateTime FinishTime
        {
            get { return _finishTime; }
            set
            {
                _finishTime = value;
                OnPropertyChanged("FinishTime");
            }
        }

        private ObservableCollection<FctTestRun> _testRunList;
        public ObservableCollection<FctTestRun> TestRunList
        {
            get { return _testRunList; }
            set
            {
                _testRunList = value;
                OnPropertyChanged("TestRunList");
            }
        }

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
