using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _211_JumabekovDarkhan_2_2
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      button1.Click += Button1_Click;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      var checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

      if (
         textBox1.Text != String.Empty &&
         textBox2.Text != String.Empty &&
         textBox3.Text != String.Empty &&
         checkedButton.Name != null &&
         dateTimePicker1.Value <= DateTime.Now
         ) 
      {
        MessageBox.Show(
          $"Фамилия: {textBox1.Text}\n" +
          $"Имя: {textBox2.Text}\n" +
          $"Отчество: {textBox3.Text}\n" +
          $"Пол: {checkedButton.Text}\n" +
          $"Дата рождения: {dateTimePicker1.Text}\n" +
          $"Семейный статус: {(checkBox1.Checked ? "Женат/замужем" : "Не женат/не замужем")}\n" +
          $"Дополнительная информация: {(richTextBox1.Text != String.Empty ? richTextBox1.Text : "отсутствует")}"      
          );
      }
      else
      {
        MessageBox.Show("Не все обязательные(*) поля отмечены корректно");
      }

    }

  }
}
