namespace OpenWeatherWPF.Models.Weather
{
  public class Weather
  {
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    private string icon;

    public string Icon { 
      get => $"https://openweathermap.org/img/wn/"+icon+".png"; 
      set => icon = value; 
    }

  
  }


}
