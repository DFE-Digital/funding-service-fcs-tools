using System.Collections.Generic;
using System.ComponentModel;

namespace TfsBuildRecorder.Entities
{
    public class BuildTestRun : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private int _totalTests;

        public int TotalTests
        {
            get { return _totalTests; }
            set
            {
                _totalTests = value;
                OnPropertyChanged("TotalTests");
            }
        }

        private int _totalTestsPassed;

        public int TotalTestsPassed
        {
            get { return _totalTestsPassed; }
            set
            {
                _totalTestsPassed = value;
                OnPropertyChanged("TotalTestsPassed");
            }
        }

        private int _totalTestsFailed;

        public int TotalTestsFailed
        {
            get { return _totalTestsFailed; }
            set
            {
                _totalTestsFailed = value;
                OnPropertyChanged("TotalTestsFailed");
            }
        }

        private int _totalTestsInconclusive;

        public int TotalTestsInconclusive
        {
            get { return _totalTestsInconclusive; }
            set
            {
                _totalTestsInconclusive = value;
                OnPropertyChanged("TotalTestsInconclusive");
            }
        }

        private int _totalTestsPending;

        public int TotalTestsPending
        {
            get { return _totalTestsPending; }
            set
            {
                _totalTestsPending = value;
                OnPropertyChanged("TotalTestsPending");
            }
        }

        private int _totalTestsInProgress;

        public int TotalTestsInProgress
        {
            get { return _totalTestsInProgress; }
            set
            {
                _totalTestsInProgress = value;
                OnPropertyChanged("TotalTestsInProgress");
            }
        }
        private int _totalTestsCompleted;

        public int TotalTestsCompleted
        {
            get { return _totalTestsCompleted; }
            set
            {
                _totalTestsCompleted = value;
                OnPropertyChanged("TotalTestsCompleted");
            }
        }
        private List<string> _failedTestNameList;

        public List<string> FailedTestNameList
        {
            get { return _failedTestNameList; }
            set
            {
                _failedTestNameList = value;
                OnPropertyChanged("FailedTestNameList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
