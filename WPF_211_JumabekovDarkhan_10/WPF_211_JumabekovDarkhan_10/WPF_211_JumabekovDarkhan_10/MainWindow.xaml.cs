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
using WPF_211_JumabekovDarkhan_10.ViewModel;

namespace WPF_211_JumabekovDarkhan_10
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public ViewModelCalc veiwModelCalc;
    public MainWindow()
    {
      InitializeComponent();
      veiwModelCalc = new ViewModelCalc();
      DataContext = veiwModelCalc;
      display.Text = veiwModelCalc.modelCalc.DisplayText;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      veiwModelCalc.ButtonClick1(sender);
  
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
      veiwModelCalc.ButtonClick2(sender);

    }

    private void Result_click(object sender, RoutedEventArgs e)
    {
      veiwModelCalc.ResultClick(sender);
    }


    private void Reset_Click(object sender, RoutedEventArgs e)
    {
      veiwModelCalc.ResetClick(sender);
    }
  }
}
