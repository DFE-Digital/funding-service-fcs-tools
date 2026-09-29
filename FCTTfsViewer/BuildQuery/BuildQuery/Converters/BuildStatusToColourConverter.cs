using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery
{
    using System.Windows.Data;
    using System.Windows.Media;
    using Microsoft.TeamFoundation.Build.Client;

    public class BuildStatusToColourConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var status = (BuildStatus) value;
            SolidColorBrush colour = new SolidColorBrush();
            switch (status)
            {
                case BuildStatus.Failed:
                    
                    colour.Color = (Color)ColorConverter.ConvertFromString("LightPink");
                    break;
                case BuildStatus.Succeeded:
                    colour.Color = (Color)ColorConverter.ConvertFromString("LightGreen");
                    break;
                case BuildStatus.PartiallySucceeded:
                    colour.Color = (Color)ColorConverter.ConvertFromString("Orange");
                    break;
                case BuildStatus.InProgress:
                    colour.Color = (Color)ColorConverter.ConvertFromString("LightBlue");
                    break;
                case BuildStatus.Stopped:
                    colour.Color = (Color)ColorConverter.ConvertFromString("Yellow");
                    break;
                default:
                    colour.Color = (Color)ColorConverter.ConvertFromString("LightGray");
                    break;
            }
            return colour;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
