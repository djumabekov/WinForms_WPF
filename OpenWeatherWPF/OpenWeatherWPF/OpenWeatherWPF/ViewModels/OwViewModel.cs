using Newtonsoft.Json;
using OpenWeatherWPF.Models;
using OpenWeatherWPF.Models.Weather;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace OpenWeatherWPF.ViewModels
{
  public class OwViewModel : INotifyPropertyChanged
  {

    private Cities cities;

    private Models.Weather.Root weather;

    private Models.Forecast.Root forecast;

    public BaseCommand GetWeatherCmd { get; set; }
    public BaseCommand GetForecastCmd { get; set; }

    public OwViewModel()
    {
      GetWeatherCmd = new BaseCommand(SetWeather);
      GetForecastCmd = new BaseCommand(SetForecast);
      SetCities();
    }

    public Cities Cities {
      get => cities;
      set {
        cities = value;
        OnPropertyChanged();
      }
    }

    public Models.Weather.Root Weather { 
      get => weather;
      set {
        weather = value;
        OnPropertyChanged();
      }
    }

    public Models.Forecast.Root Forecast {
      get => forecast;
      set {
        forecast = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(
        [CallerMemberName] string pName = "")
    {
      PropertyChanged?
          .Invoke(this
          , new PropertyChangedEventArgs(pName));
    }

    private async void SetWeather(object city)
    {
      HttpClient client = (HttpClient)App.Current.Properties["httpClient"];
      string url = string.Empty;
      float lat = (city as City).coord.lat;
      float lon = (city as City).coord.lon;
      if (lat > 0 && lon > 0)
      {
        url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=cebb584312c97155660e87b65b8fa595";
      }
      var responce = await client.GetAsync(url);
      if (responce.IsSuccessStatusCode)
      {
        var content = await responce.Content.ReadAsStringAsync();
        Weather = JsonConvert.DeserializeObject<Models.Weather.Root>(content);
      }
    }

    private async void SetForecast(object city)
    {
      HttpClient client = (HttpClient)App.Current.Properties["httpClient"];
      string url = string.Empty;
      float lat = (city as City).coord.lat;
      float lon = (city as City).coord.lon;
      if (lat > 0 && lon > 0)
      {
        url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&appid=cebb584312c97155660e87b65b8fa595";
      }
      var responce = await client.GetAsync(url);
      if (responce.IsSuccessStatusCode)
      {
        var content = await responce.Content.ReadAsStringAsync();
        Forecast = JsonConvert.DeserializeObject<Models.Forecast.Root>(content);
      }
    }

    private void SetCities()
    {
      var jsonCities = File.ReadAllText("city.list.json");
      var citiesList = JsonConvert.DeserializeObject<List<City>>(jsonCities);
      Cities = new Cities(citiesList);
      //MessageBox.Show(cities.cities[0].coord.lat.ToString());
    }
  }

}
