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
  public class SpeedDoubleToSpeedIntConverter : IValueConverter
  {
    public object Convert(object value
           , Type targetType
           , object parameter
           , CultureInfo culture)
    {
      double speedDouble = (double)value;
      int tempInt = (int)Math.Round(speedDouble);

      string tempString = tempInt.ToString();
      return tempString + " м/с";
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
