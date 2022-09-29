using System;
using System.Collections.Generic;
using System.Globalization;
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
using WPF_211_JumabekovDarkhan_12.ViewModel;

namespace WPF_211_JumabekovDarkhan_12
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public MainWindow()
    {
    
      CultureInfo.CurrentUICulture = new CultureInfo(Properties.Settings.Default.Lang.ToString());
      InitializeComponent();
      DataContext = new LoginViewModel();
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        ComboBox comboBox = (ComboBox)sender;
        ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
        CultureInfo.CurrentUICulture = new CultureInfo(selectedItem.Tag.ToString());

        Properties.Settings.Default.Lang = selectedItem.Tag.ToString();
        Properties.Settings.Default.Save();

        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        Application.Current.Shutdown();
      
    }
  }
}
