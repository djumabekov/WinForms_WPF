using System;
using System.Collections.Generic;
using System.Globalization;

namespace OpenWeatherWPF.Models.Forecast
{
  public class List
  {
    public int dt { get; set; }
    public Main main { get; set; }
    public List<Weather> weather { get; set; }
    public Clouds clouds { get; set; }
    public Wind wind { get; set; }
    public int visibility { get; set; }
    public float pop { get; set; }
    public Sys sys { get; set; }
    public string dt_txt { get; set; }

    public string day { get; set; }
    public string date { get; set; }

    //public List()
    //{
    //  setDayOfWeek();
    //}

    //private void setDayOfWeek()
    //{

      //DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(dt).AddDays(+1); ;
      //date = d.ToString("dd/MM", CultureInfo.InvariantCulture);

      //day = d.DayOfWeek.ToString();

      //switch (dayofweek)
      //{
      //  case 1:
      //    day = "Monday"; break;
      //  case 2:
      //    day = "Tuesday"; break;
      //  case 3:
      //    day = "Wednesday"; break;
      //  case 4:
      //    day = "Thursday"; break;
      //  case 5:
      //    day = "Friday"; break;
      //  case 6:
      //    day = "Saturday"; break;
      //  case 7:
      //    day = "Sunday"; break;
      //}
    //}
  }


}
