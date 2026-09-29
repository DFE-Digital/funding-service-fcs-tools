using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models
{
    using System.ComponentModel;

    public class BurnDownDataPoint  : INotifyPropertyChanged
    {

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        private int _index;

        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                OnPropertyChanged("Index");
            }
        }
        private double? _remainingWorkHours;

        public double? RemainingWorkHours
        {
            get { return _remainingWorkHours; }
            set
            {
                _remainingWorkHours = value;
                OnPropertyChanged("RemainingWorkHours");
            }
        }
        private double? _idealTrendHours;

        public double? IdealTrendHours
        {
            get { return _idealTrendHours; }
            set
            {
                _idealTrendHours = value;
                OnPropertyChanged("IdealTrendHours");
            }
        }
        private double _actualTrendHours;

        public double ActualTrendHours
        {
            get { return _actualTrendHours; }
            set
            {
                _actualTrendHours = value;
                OnPropertyChanged("ActualTrendHours");
            }
        }
        private double? _remainingWorkPoints;

        public double? RemainingWorkPoints
        {
            get { return _remainingWorkPoints; }
            set
            {
                _remainingWorkPoints = value;
                OnPropertyChanged("RemainingWorkPoints");
            }
        }
        private double? _idealTrendPoints;

        public double? IdealTrendPoints
        {
            get { return _idealTrendPoints; }
            set
            {
                _idealTrendPoints = value;
                OnPropertyChanged("IdealTrendPoints");
            }
        }
        private double _actualTrendPoints;

        public double ActualTrendPoints
        {
            get { return _actualTrendPoints; }
            set
            {
                _actualTrendPoints = value;
                OnPropertyChanged("ActualTrendPoints");
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
