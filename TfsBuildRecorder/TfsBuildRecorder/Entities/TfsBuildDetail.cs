using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Microsoft.TeamFoundation.Build.Client;

namespace TfsBuildRecorder.Entities
{
    public class TfsBuildDetail : INotifyPropertyChanged
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
        private DateTime? _startTime;

        public DateTime? StartTime
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

        public string FinishTimeAsString { get; set; }

        private List<BuildTestRun> _testRunList;
        
        public List<BuildTestRun> TestRunList
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
                handler.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string ToPipedString()
        {
            var noneNullStartTime = StartTime ?? new DateTime();
            return string.Format("{0},{1},{2},{3},{4}", DefinitionName,noneNullStartTime.ToString("G", new CultureInfo("en-GB")),FinishTime.ToString("G", new CultureInfo("en-GB")),FinishTime.ToString("ddMMMyyyyhhmm"),Status);
        }
    }
}
