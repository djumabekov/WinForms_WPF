using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenWeatherWPF.Models.Weather
{
  public class Root
  {
    public Coord coord { get; set; }
    public List<Weather> weather { get; set; }
    public string @base { get; set; }
    public Main main { get; set; }
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Clouds clouds { get; set; }
    public int dt { get; set; }
    public Sys sys { get; set; }
    public int timezone { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int cod { get; set; }
    public string day { get; set; }
    public string date { get; set; }

    public Root()
    {
      setDayOfWeek();
    }

    private void setDayOfWeek() {
      DateTime d = DateTime.Now;
      int dayofweek = (int)d.DayOfWeek;

      switch (dayofweek)
      {
        case 1:
          day = "Monday"; break;
        case 2:
          day = "Tuesday"; break;
        case 3:
          day = "Wednesday"; break;
        case 4:
          day = "Thursday"; break;
        case 5:
          day = "Friday"; break;
        case 6:
          day = "Saturday"; break;
        case 7:
          day = "Sunday"; break;
      }

      date = d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
  }


}
