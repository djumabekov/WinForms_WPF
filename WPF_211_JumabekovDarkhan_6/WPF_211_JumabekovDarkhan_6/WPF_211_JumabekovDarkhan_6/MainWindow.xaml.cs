using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_211_JumabekovDarkhan_6
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public List<AnimalItem> AlimalItems { get; set; }
    public class AnimalItem
    {
      public string Name { get; set; }
      public string Description { get; set; }
      public BitmapImage Photo { get; set; }

      public override string ToString()
      {
        return $"{Name}";
      }
    }
    public MainWindow()
    {
      InitializeComponent();
      AlimalItems = new List<AnimalItem>()
        {
            new AnimalItem()
            {
              Name = "Собака",
              Description="Домашнее животное, одно из наиболее популярных животных-компаньонов.",
              Photo= new BitmapImage(new Uri(Directory.GetCurrentDirectory()+"../../../images/dog.jpg", UriKind.RelativeOrAbsolute))
            },
            new AnimalItem()
            {
              Name = "Кошка",
              Description = "Милые животные, от которых исходит невероятная энергия тепла и умиротворения. ",
              Photo= new BitmapImage(new Uri(Directory.GetCurrentDirectory()+"../../../images/cat.jpg", UriKind.RelativeOrAbsolute))
            },
            new AnimalItem()
            {
              Name = "Лошадь",
              Description = "Животное из семейства лошадиных отряда непарнокопытных, одомашненный потомок дикой лошади.",
              Photo= new BitmapImage(new Uri(Directory.GetCurrentDirectory()+"../../../images/horse.jpg", UriKind.RelativeOrAbsolute))
            },
            new AnimalItem()
            {
              Name = "Попугай",
              Description = "Уникальные и яркие представители класса птицы, способные повторять человеческую речь, показывать сложные трюки и подражать поведению своего хозяина.",
              Photo= new BitmapImage(new Uri(Directory.GetCurrentDirectory()+"../../../images/parrot.jpg", UriKind.RelativeOrAbsolute))
            }
          };
      MainLV.ItemsSource = AlimalItems;
    }

    private void DetailBtn_Click(object sender, RoutedEventArgs e)
    {
      var item = MainLV.SelectedItem as AnimalItem;
      if (item != null)
      {
        var detailWIndow = new DetailWindow(item);
        detailWIndow.ShowDialog();
      }
      else
      {
        MessageBox.Show("Выберите животное");
      }
    }


  }
}
