using System;
using System.ComponentModel;
using System.Windows.Controls;
using WPF_211_JumabekovDarkhan_10.Model;

namespace WPF_211_JumabekovDarkhan_10.ViewModel
{
  public class ViewModelCalc : INotifyPropertyChanged
  {
    public ModelCalc modelCalc;

    public event PropertyChangedEventHandler PropertyChanged;

    public ViewModelCalc()
    {
      modelCalc = new ModelCalc();
    }

    public string DisplayText {
      get { return modelCalc.DisplayText; }
      set {
        modelCalc.DisplayText = value;
        OnPropertyChanged("DisplayText");
      }
    }
    public string HistoryText {
      get { return modelCalc.HistoryText; }
      set {
        modelCalc.HistoryText = value;
        OnPropertyChanged("HistoryText");
      }
    }
    public bool IsResult {
      get { return modelCalc.isResult; }
      set {
        modelCalc.isResult = value;
        OnPropertyChanged("IsResult");
      }
    }
    public void OnPropertyChanged(string prop = "")
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

    public void ButtonClick1(object sender)
    {
      if (IsResult)
      {
        DisplayText = "";
        IsResult = false;
      }
      Button b = (Button)sender;

      DisplayText += b.Content.ToString();
    }

    public void ButtonClick2(object sender)
    {
      if (!DisplayText.Contains("+") && !DisplayText.Contains("-") && !DisplayText.Contains("*") && !DisplayText.Contains("/") && !DisplayText.Contains("="))
      {
        Button b = (Button)sender;
        DisplayText += b.Content.ToString();
      }
    }

    public void ResultClick(object sender)
    {
      try
      {
        if (!IsResult)
        {
          result();
        }
      }
      catch (Exception)
      {
        DisplayText = "Error!";
      }
    }

  
    public void ResetClick(object sender)
    {
      DisplayText = "";
    }

    private void result()
    {
      string op;
      int iOp = 0;
      if (DisplayText.Contains("+"))
      {
        iOp = DisplayText.IndexOf("+");
      }
      else if (DisplayText.Contains("-"))
      {
        iOp = DisplayText.IndexOf("-");
      }
      else if (DisplayText.Contains("*"))
      {
        iOp = DisplayText.IndexOf("*");
      }
      else if (DisplayText.Contains("/"))
      {
        iOp = DisplayText.IndexOf("/");
      }
      else
      {
        //error    
      }

      op = DisplayText.Substring(iOp, 1);
      double op1 = Convert.ToDouble(DisplayText.Substring(0, iOp));
      double op2 = Convert.ToDouble(DisplayText.Substring(iOp + 1, DisplayText.Length - iOp - 1));

      if (op == "+")
      {
        DisplayText += "=" + (op1 + op2);
      }
      else if (op == "-")
      {
        DisplayText += "=" + (op1 - op2);
      }
      else if (op == "*")
      {
        DisplayText += "=" + (op1 * op2);
      }
      else
      {
        DisplayText += "=" + (op2 != 0 ? (op1 / op2) : 0) ;
      }
 
      HistoryText += DisplayText + "\n";
      IsResult = true;
    }

  }
}
