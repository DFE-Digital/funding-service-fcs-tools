using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery
{
    using TfsData.Models;
    using System.Collections.ObjectModel;
    using System.Windows.Data;

    public class IdealDataPointNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var list = ((ObservableCollection<BurnDownDataPoint>)value).ToList();
            list = list.Where(x => x.IdealTrendHours != null).ToList();
            
            return new ObservableCollection<BurnDownDataPoint>(list);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
