﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserJournal.Models;
using UserJournal.ViewModels;

namespace UserJournal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;

          List<string> styles = new List<string> { "light", "dark" };
          styleBox.SelectionChanged += ThemeChange;
          styleBox.ItemsSource = styles;
          styleBox.SelectedItem = "dark";
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
          string style = styleBox.SelectedItem as string;
          var uri = new Uri("Views/" + style + ".xaml", UriKind.Relative);
          ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
          Application.Current.Resources.Clear();
          Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
  }
}
