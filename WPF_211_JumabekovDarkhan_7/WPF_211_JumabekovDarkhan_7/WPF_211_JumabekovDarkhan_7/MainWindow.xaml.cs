using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_211_JumabekovDarkhan_7
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public List<Item1> Items1 { get; set; }
    public List<Item2> Items2 { get; set; }
    public List<Item3> Items3 { get; set; }
    public class Item1
    {
      public string Item1First { get; set; }
      public string Item1Second { get; set; }

      public override string ToString()
      {
        return $"{Item1First} {Item1Second}";
      }
    }
    public class Item2
    {
      public string Item2First { get; set; }
      public string Item2Second { get; set; }

      public override string ToString()
      {
        return $"{Item2First} {Item2Second}";
      }
    }
    public class Item3
    {
      public string Item3First { get; set; }
      public string Item3Second { get; set; }
      public string Item3Third { get; set; }
      public string Item3Fourth { get; set; }

      public override string ToString()
      {
        return $"{Item3First} {Item3Second} {Item3Third} {Item3Fourth}";
      }
    }
    public MainWindow()
    {
      InitializeComponent();
      Items1 = new List<Item1>()
      {
        new Item1()
        {
          Item1First = "Item1_1",
          Item1Second = "Item1_2"
        },
         new Item1()
        {
          Item1First = "Item1_3",
          Item1Second = "Item1_4"
        },
           new Item1()
        {
          Item1First = "Item1_5",
          Item1Second = "Item1_6"
        }
      };
      Items2 = new List<Item2>()
      {
        new Item2()
        {
          Item2First = "Item2_1",
          Item2Second = "Item2_2"
        },
         new Item2()
        {
          Item2First = "Item2_3",
          Item2Second = "Item2_4"
        },
           new Item2()
        {
          Item2First = "Item2_5",
          Item2Second = "Item2_6"
        }
      };
      FirstLV.ItemsSource = Items1;
      SecondLV.ItemsSource = Items2;
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
