using System;
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
using WPF_211_JumabekovDarkhan_9.Model;

namespace WPF_211_JumabekovDarkhan_9
{
  /// <summary>
  /// Логика взаимодействия для Page1.xaml
  /// </summary>
  public partial class Page1 : Page
  {
    public static List<Item3> Items3 { get; set; }
    public Page1()
    {
      InitializeComponent();
      DataContext = new ViewModel.ViewModel();
      FirstLV.ItemsSource = ViewModel.ViewModel.Items1;
      SecondLV.ItemsSource = ViewModel.ViewModel.Items2;
    }
    private void JoinBtn_Click(object sender, RoutedEventArgs e)
    {
      var item1 = FirstLV.SelectedItem as Item1;
      var item2 = SecondLV.SelectedItem as Item2;
      if (item1 != null && item2 != null)
      {
        Items3 = new List<Item3>()
        {
          new Item3()
          {
            Item3First = item1.Item1First,
            Item3Second = item1.Item1Second,
            Item3Third = item2.Item2First,
            Item3Fourth = item2.Item2Second,
          },
        };
        ThirdLV.ItemsSource = null;
        ThirdLV.ItemsSource = Items3;
      }
      else
      {
        MessageBox.Show("Не выбран элемент");
      }
    }

    private void ThirdLV_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
      var item = (sender as ListView).SelectedItem as Item3;
      MainStack.DataContext = null;
      MainStack.DataContext = item;
    }
  }
}
