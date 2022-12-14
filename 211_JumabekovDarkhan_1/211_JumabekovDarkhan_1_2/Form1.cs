using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _211_JumabekovDarkhan_1_2
{
  public partial class Form1 : Form
  {
    private List<Color> defaultColors = new List<Color> { Color.Blue, Color.Brown };
    private List<Color> customColors = new List<Color> { Color.Red, Color.Yellow };
    public Form1()
    {
      InitializeComponent();
      ChangeColor(defaultColors);
    }
    Bitmap Gradient2D(Rectangle r, Color c1, Color c2, Color c3, Color c4)
    {
      Bitmap bmp = new Bitmap(r.Width, r.Height);

      float delta12R = 1f * (c2.R - c1.R) / r.Height;
      float delta12G = 1f * (c2.G - c1.G) / r.Height;
      float delta12B = 1f * (c2.B - c1.B) / r.Height;
      float delta34R = 1f * (c4.R - c3.R) / r.Height;
      float delta34G = 1f * (c4.G - c3.G) / r.Height;
      float delta34B = 1f * (c4.B - c3.B) / r.Height;
      using (Graphics G = Graphics.FromImage(bmp))
        for (int y = 0; y < r.Height; y++)
        {
          Color c12 = Color.FromArgb(255, c1.R + (int)(y * delta12R),
                c1.G + (int)(y * delta12G), c1.B + (int)(y * delta12B));
          Color c34 = Color.FromArgb(255, c3.R + (int)(y * delta34R),
                c3.G + (int)(y * delta34G), c3.B + (int)(y * delta34B));
          using (LinearGradientBrush lgBrush = new LinearGradientBrush(
                new Rectangle(0, y, r.Width, 1), c12, c34, 0f))
          { G.FillRectangle(lgBrush, 0, y, r.Width, 1); }
        }
      return bmp;
    }
    private void ChangeColor(List<Color> colors)
    {
      BackgroundImage = Gradient2D(ClientRectangle, Color.Black, Color.FromArgb(0, 255, 0, 255), colors[0], colors[1]);
    }

    private void SetDefaultColor(object sender, EventArgs e)
    {
      ChangeColor(defaultColors);
    }

    private void SetCustomColor(object sender, EventArgs e)
    {
      ChangeColor(customColors);
    }

    private void ClosingConfirm(object sender, FormClosingEventArgs e)
    {
      if (MessageBox.Show("Уверены закрыт?", "Message", MessageBoxButtons.YesNo) == DialogResult.No)
        e.Cancel = true;
      else
        e.Cancel = false;
    }
  }
}
