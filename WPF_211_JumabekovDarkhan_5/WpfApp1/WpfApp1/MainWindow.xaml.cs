using System;
using System.Collections;
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

namespace WpfApp1
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  /// 

  public class Contacts
  {
    public List<string> ContactsItems { get; set; }


  }
  public partial class MainWindow : Window
  {
    Contacts contacts = new Contacts
    {
      ContactsItems = new List<string>
        {
          "Иванов",
          "Петров",
          "Сидоров",
        }
    };
   
    public MainWindow()
    {
      InitializeComponent();
       MainStack.DataContext = contacts;
    
    }

    

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      contacts.ContactsItems.RemoveAt(Lst);
    }
  }
}
