using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class FctFailedTest
     : INotifyPropertyChanged
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

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        private string _testRunName;

        public string TestRunName
        {
            get { return _testRunName; }
            set
            {
                _testRunName = value;
                OnPropertyChanged("TestRunName");
            }
        }
        private string _buildName;

        public string BuildName
        {
            get { return _buildName; }
            set
            {
                _buildName = value;
                OnPropertyChanged("BuildName");
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
