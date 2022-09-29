using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211_JumabekovDarkhan_2_1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      button1.MouseEnter += Button1_MouseEnter;
      button1.Click += Button1_Click;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Вы поймали кнопку", "Победа!");
    }

    private void Button1_MouseEnter(object sender, EventArgs e)
    {
      Random r = new Random();
      button1.Left = r.Next(0, this.ClientSize.Width - button1.Width);
      button1.Top = r.Next(0, this.ClientSize.Height - button1.Height);
      button1.Refresh();
    }
  }
}
