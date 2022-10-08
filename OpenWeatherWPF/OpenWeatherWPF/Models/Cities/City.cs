using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherWPF.Models
{
  public class Coord {
    public float lon { get; set; }
    public float lat { get; set; }

  }
  public class City
  {
    public int id { get; set; }
    public string name{ get; set; }
    public string state { get; set; }
    public string country { get; set; }
    public Coord coord { get; set; }
  }
}


