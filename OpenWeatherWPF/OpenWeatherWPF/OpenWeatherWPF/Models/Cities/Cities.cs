using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherWPF.Models
{
  public class Cities
  {
    public List<City> cities { get; set; }

    public Cities(List<City> cities)
    {
      this.cities = cities;
    }
  }
}


