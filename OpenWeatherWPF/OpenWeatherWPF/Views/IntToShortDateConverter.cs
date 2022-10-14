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
  public class IntToShortDateConverter : IValueConverter
  {
    public object Convert(object value
           , Type targetType
           , object parameter
           , CultureInfo culture)
    {
      var dt = (int)value;

      DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(dt);

      return d.ToString("dd/MM", CultureInfo.InvariantCulture);


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
