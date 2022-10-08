using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherWPF.Models
{
  public class AppSettings
  {
    public string City { get; set; }
    public float Lat { get; set; }
    public float Lon { get; set; }
    public int SwitchView { get; set; }
    public int SelectedCityIndex { get; set; }
    public string UiCulture { get; set; }
  }
}
