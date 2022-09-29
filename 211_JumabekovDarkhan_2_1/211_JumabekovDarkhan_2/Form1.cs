using System;
using System.Drawing;
using System.Windows.Forms;

namespace _211_JumabekovDarkhan_2
{
  public partial class Form1 : Form
  {
    private static TimeSpan _timeSpan;

    private static int _timerInterval = 1000;
    private static int _timerStart = 60;
    private static int _timerEnd = 0;
    private static int _timerShowMessage = 40;
    private static int _smsCode;
    public Form1()
    {
      InitializeComponent();
      button1.Click += Button1_Click;
      button2.Click += Button2_Click;

    }

    private void Button2_Click(object sender, EventArgs e)
    {
      if (textBox1.Text.Trim() == _smsCode.ToString())
      {
        textBox1.ForeColor = Color.Green;
        timer1.Tick -= Timer1_Tick;
        timer1.Stop();
        MessageBox.Show("Вы ввели правильный код", "SMS-code check");
        Close();
      }
      else
      {
        textBox1.ForeColor = Color.Red;
      }
    }

    private void Button1_Click(object sender, EventArgs e)
    {

      timer1.Tick += Timer1_Tick;
      _timeSpan = TimeSpan.FromSeconds(_timerStart);
      timer1.Interval = _timerInterval;
      timer1.Start();

      button1.Enabled = false;
      button2.Enabled = true;
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {

      _timeSpan = _timeSpan - TimeSpan.FromSeconds(1);
      label1.Text = string.Format("00:{0}", _timeSpan.Seconds.ToString("D2"));
      if (_timeSpan.Seconds == _timerShowMessage)
      {
        Random rnd = new Random();
        _smsCode = rnd.Next(100000, 999999);
        MessageBox.Show(_smsCode.ToString(), "SMS-code");
      }

      if (_timeSpan.Seconds == _timerEnd)
      {
        timer1.Tick -= Timer1_Tick;
        timer1.Stop();
        button1.Enabled = true;
        button2.Enabled = false;
        textBox1.ForeColor = Color.Black;
      }
    }
  }
}
