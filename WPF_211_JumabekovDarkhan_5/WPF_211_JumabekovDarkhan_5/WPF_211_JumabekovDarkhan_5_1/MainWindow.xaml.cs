using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPF_211_JumabekovDarkhan_5_1
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
      MessageBox.Show("Hello!");
        }

    private void Hyperlink_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("Вы зарегистрированы");
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      Process.Start(new ProcessStartInfo("https://www.facebook.com") { UseShellExecute = true });
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
      Process.Start(new ProcessStartInfo("https://www.google.com") { UseShellExecute = true });

    }
  }
}
