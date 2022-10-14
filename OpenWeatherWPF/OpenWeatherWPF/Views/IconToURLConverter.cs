using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace OpenWeatherWPF.Views
{
  public class IconToURLConverter : IValueConverter
  {
    public object Convert(object value
           , Type targetType
           , object parameter
           , CultureInfo culture)
    {
      var icon = (string)value;

      return $"https://openweathermap.org/img/wn/{icon}@2x.png";


    }

    public object ConvertBack(object value
        , Type targetType
        , object parameter
        , CultureInfo culture)
    {
      return Binding.DoNothing;
    }
  }
}
