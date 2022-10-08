using Newtonsoft.Json;
using OpenWeatherWPF.Models;
using OpenWeatherWPF.ViewModels;
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace OpenWeatherWPF
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private OwViewModel owViewModel;
    public MainWindow()
    {
      var jsonContent = File.ReadAllText("../../langSettings.json");
      LangSettings lang = JsonConvert.DeserializeObject<LangSettings>(jsonContent);
      CultureInfo.CurrentUICulture = new CultureInfo(lang.UiCulture);

      owViewModel = new OwViewModel();
      owViewModel.SelectedLang = lang;
      DataContext = owViewModel;
      InitializeComponent();


    }

    private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
    {
      owViewModel.FilterCitiesCmd.Execute(sender);
    }


    public void RemoveText(object sender, EventArgs e)
    {
      TextBox instance = (TextBox)sender;
      if (instance.Text == instance.Tag.ToString())
      {
        instance.Text = "";
      }
    }

    public void AddText(object sender, EventArgs e)
    {
      TextBox instance = (TextBox)sender;
      if (string.IsNullOrWhiteSpace(instance.Text))
      {
        instance.Text = instance.Tag.ToString();
      }
    }
  }
}
