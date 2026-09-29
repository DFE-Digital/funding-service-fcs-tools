using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class FctTask
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

        private string _storyName;

        public string StoryName
        {
            get { return _storyName; }
            set
            {
                _storyName = value;
                OnPropertyChanged("StoryName");
            }
        }

        private string _assigned;

        public string Assigned
        {
            get { return _assigned; }
            set
            {
                _assigned = value;
                OnPropertyChanged("Assigned");
            }
        }
        private DateTime _firstInProgressDate;

        public DateTime FirstInProgressDate
        {
            get { return _firstInProgressDate; }
            set
            {
                _firstInProgressDate = value;
                OnPropertyChanged("FirstInProgressDate");
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
