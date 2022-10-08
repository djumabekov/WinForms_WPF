using Newtonsoft.Json;
using OpenWeatherWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace OpenWeatherWPF.ViewModels
{
  public class OwViewModel : INotifyPropertyChanged
  {

    private Cities cities;

    private Models.Weather.Root weather;

    private Models.Forecast.Root forecast;

    private Models.City selectedCityItem;

    private int switchView { get; set; }

    private AppSettings appSettings;

    private LangSettings selectedLang;

    public List<LangSettings> Languages { get; set; }

    private List<Models.City> filteredCityList;

    public BaseCommand GetWeatherCmd { get; set; }
    public BaseCommand GetForecastCmd { get; set; }
    public BaseCommand FilterCitiesCmd { get; set; }
    public BaseCommand ClearTxtFilter { get; set; }
    public BaseCommand RestartAppCmd { get; set; }
    
    public OwViewModel()
    {
      GetWeatherCmd = new BaseCommand(SetWeather);
      GetForecastCmd = new BaseCommand(SetForecast);
      FilterCitiesCmd = new BaseCommand(SetFilterCities);
      ClearTxtFilter = new BaseCommand(ClearTextBox);
      RestartAppCmd = new BaseCommand(RestartApp);
      SetCities();
      FilteredCityList = new List<Models.City>();
      AppSettings = GetAppSettings();
      SwitchView = AppSettings.City != null ? 0 : 2;
      SetWeather(SelectedCityItem);

      Languages = new List<LangSettings>()
            {
                new LangSettings{UiCulture="en-US"}
                ,new LangSettings{UiCulture= "kk" }
                , new LangSettings{ UiCulture="ru" }
            };
      var langStg = GetAppSettings();
      SelectedLang = GetLangSettings();
    }

    private void RestartApp(object obj)
    {
      System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
      System.Windows.Application.Current.Shutdown();
    }

    public LangSettings SelectedLang {
      get => selectedLang;
      set {
        selectedLang = value;
        SetLangSettings(value);
        OnPropertyChanged();
      }
    }

    private void SetLangSettings(LangSettings value)
    {
      var json = JsonConvert.SerializeObject(value);
      File.WriteAllText("../../langSettings.json", json);

    }

    public static LangSettings GetLangSettings()
    {
      var jsonContent = File.ReadAllText("../../langSettings.json");
      LangSettings r = JsonConvert
          .DeserializeObject<LangSettings>(jsonContent);
      return r;
    }

    public int SwitchView {
      get => switchView;
      set {
        switchView = value;
        OnPropertyChanged();
      }
    }

    private void ClearTextBox(object txtFilter)
    {
      TextBox instance = (TextBox)txtFilter;
      instance.Text = "";
    }

    public List<Models.City> FilteredCityList {
      get => filteredCityList;
      set {
        filteredCityList = value;
        OnPropertyChanged();
      }
    }

    private void SetFilterCities(object txtFilter)
    {
      TextBox instance = (TextBox)txtFilter;
      FilteredCityList =
        !string.IsNullOrWhiteSpace(instance.Text) && instance.Text != instance.Tag.ToString() ?
        cities.cities.Where(c => c.name.Contains(instance.Text)).OrderBy(c => c.name.Length).ToList()
        :
        cities.cities.Select(c => c).ToList();
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

    public Models.City SelectedCityItem {
      get => selectedCityItem;
      set {
        selectedCityItem = value;
        OnPropertyChanged();
        GetWeatherCmd.Execute(selectedCityItem);
        AppSettings temp = new AppSettings();

        temp.City = value.name;
        temp.Lat = value.coord.lat;
        temp.Lon = value.coord.lon;
        temp.SwitchView = SwitchView;
        AppSettings = temp;
      }
    }

    public AppSettings AppSettings {
      get => appSettings;
      set {
        appSettings = value;
        SetAppSettings(value);
        OnPropertyChanged();
      }
    }

    private void SetAppSettings(AppSettings value)
    {
      var json = JsonConvert.SerializeObject(value);
      File.WriteAllText("../../appSettings.json", json);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(
        [CallerMemberName] string pName = "")
    {
      PropertyChanged?
          .Invoke(this
          , new PropertyChangedEventArgs(pName));
    }

    public static AppSettings GetAppSettings()
    {
      var jsonContent = File.ReadAllText("../../appSettings.json");
      AppSettings r = JsonConvert
          .DeserializeObject<AppSettings>(jsonContent);
      return r;
    }

    private async void SetWeather(object city)
    {
      float lat = 0;
      float lon = 0;

      if (AppSettings.Lat != 0 && AppSettings.Lon != 0)
      {
        lat = AppSettings.Lat;
        lon = AppSettings.Lon;
      }
      else if (SelectedCityItem != null)
      {
        lat = SelectedCityItem.coord.lat;
        lon = SelectedCityItem.coord.lon;
      }

      if (lat != 0 && lat != 0)
      {
        HttpClient client = (HttpClient)App.Current.Properties["httpClient"];
        string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=cebb584312c97155660e87b65b8fa595";

        var responce = await client.GetAsync(url);
        if (responce.IsSuccessStatusCode)
        {
          var content = await responce.Content.ReadAsStringAsync();
          Weather = JsonConvert.DeserializeObject<Models.Weather.Root>(content);
        }
      }
      SwitchView = 0;
    }

    private async void SetForecast(object city)
    {
      float lat = 0;
      float lon = 0;

      if (AppSettings.Lat != 0 && AppSettings.Lon != 0)
      {
        lat = AppSettings.Lat;
        lon = AppSettings.Lon;
      }
      else if (SelectedCityItem != null)
      {
        lat = SelectedCityItem.coord.lat;
        lon = SelectedCityItem.coord.lon;
      }
      if (lat != 0 && lat != 0)
      {
        HttpClient client = (HttpClient)App.Current.Properties["httpClient"];

        string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&appid=cebb584312c97155660e87b65b8fa595";

        var responce = await client.GetAsync(url);
        if (responce.IsSuccessStatusCode)
        {
          var content = await responce.Content.ReadAsStringAsync();
          Forecast = JsonConvert.DeserializeObject<Models.Forecast.Root>(content);
          List<Models.Forecast.List> temp = new List<Models.Forecast.List>();
          for (var i = 0; i < Forecast.list.Count; i += 8)
          {
            temp.Add(Forecast.list[i]);
          }
          Forecast.list.Clear();
          Forecast.list = temp;
        }
      }
      SwitchView = 1;
    }

    private void SetCities()
    {
      var jsonCities = File.ReadAllText("../../Data/city.list.json");
      var citiesList = JsonConvert.DeserializeObject<List<Models.City>>(jsonCities);
      Cities = new Cities(citiesList);
    }
  }

}
