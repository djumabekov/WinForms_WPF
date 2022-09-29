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
using System.Windows.Shapes;

namespace WPF_211_JumabekovDarkhan_6
{
  /// <summary>
  /// Логика взаимодействия для DetailWindow.xaml
  /// </summary>
  public partial class DetailWindow : Window
  {
    public MainWindow.AnimalItem AnimalItem { get; set; }

    public DetailWindow(MainWindow.AnimalItem animalItem)
    {
      InitializeComponent();
      this.AnimalItem = animalItem;
      MainStack.DataContext = AnimalItem;
    }

    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
