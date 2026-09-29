using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class FctBurndown : INotifyPropertyChanged
    {
        private string _team;
        public string Team
        {
            get
            {
                return _team;
            }
            set
            {
                _team = value;
                OnPropertyChanged("Team");
            }
        }
        private string _iteration;
        public string Iteration
        {
            get
            {
                return _iteration;
            }
            set
            {
                _iteration = value;
                OnPropertyChanged("Iteration");
            }
        }

        private ObservableCollection<BurnDownDataPoint> _dataPoints;
        public ObservableCollection<BurnDownDataPoint> DataPoints
        {
            get
            {
                return _dataPoints;
            }
            set
            {
                _dataPoints = value;
                OnPropertyChanged("DataPoints");
            }
        }

        public static FctBurndown CombineBurndowns(List<FctBurndown> burndownList)
        {
            FctBurndown combinedBurnDown = new FctBurndown
            {
                Team = "All",
            };

            if (burndownList.Count(y => y.Iteration == burndownList[0].Iteration) != burndownList.Count)
            {
                throw new ArgumentException("Cannot combine burndowns from different iterations");
            }

            combinedBurnDown.DataPoints =
                new ObservableCollection<BurnDownDataPoint>(
                    burndownList.SelectMany(x => x.DataPoints).GroupBy(x => x.Date, (d, bd) =>
                    {
                        return new BurnDownDataPoint()
                        {
                            Date = d,
                            Index=bd.ElementAt(0).Index,
                            RemainingWorkHours = bd.ElementAt(0).RemainingWorkHours == null ? null : bd.Sum(x => x.RemainingWorkHours),
                            RemainingWorkPoints = bd.ElementAt(0).RemainingWorkPoints == null ? null : bd.Sum(x => x.RemainingWorkPoints),
                            IdealTrendHours=null,
                            IdealTrendPoints=null
                        };

                    }));
            combinedBurnDown.DataPoints.First().IdealTrendHours = combinedBurnDown.DataPoints.First().RemainingWorkHours;
            combinedBurnDown.DataPoints.First().IdealTrendPoints = combinedBurnDown.DataPoints.First().RemainingWorkPoints;
            combinedBurnDown.DataPoints.Last().IdealTrendHours = 0;
            combinedBurnDown.DataPoints.Last().IdealTrendPoints = 0;

            return combinedBurnDown;
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
