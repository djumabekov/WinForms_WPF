using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherWPF.Models.Forecast
{

  public class Wind
  {
    public double speed { get; set; }
    public int deg { get; set; }
    public double gust { get; set; }
  }

}
