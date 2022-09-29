using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211_JumabekovDarkhan_1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      List<string> resume = new List<string>();
      resume.Add("ФИО: Джумабеков Д.");
      resume.Add("Адрес: Астана, пр.Абая, дом 12, кв.1");
      resume.Add("Образование: высшее");
      resume.Add("Сеймейное положение: женат, 2 детей");
      resume.Add("Цель: получение работы");

      int i = 0;
      foreach(var item in resume)
      {
        MessageBox.Show(item, $"Поряд. номер: {++i}, кол. символов: {item.Length} ");
      }
      Close();
    }
  }
}
