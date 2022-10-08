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
  public class FeelsLikeDoubleToFeelsLikeIntConverter : IValueConverter
  {
    public object Convert(object value
           , Type targetType
           , object parameter
           , CultureInfo culture)
    {
      double feelsLikeDouble = (double)value;
      int feelsLikeInt = (int)Math.Round(feelsLikeDouble);

      string tempString = feelsLikeInt.ToString();
      return tempString + "°";
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
