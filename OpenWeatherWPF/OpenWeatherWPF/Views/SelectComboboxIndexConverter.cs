using OpenWeatherWPF.Models;
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
  public class SelectComboboxIndexConverter : IValueConverter
  {
    public object Convert(object value
           , Type targetType
           , object parameter
           , CultureInfo culture)
    {
      var selectedItem = (value as LangSettings).UiCulture;

      string result = null;
      switch (selectedItem)
      {
        case "en-US": result = "0"; break;
        case "kk": result = "1"; break;
        case "ru": result = "2"; break;
      }

      return result;
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
