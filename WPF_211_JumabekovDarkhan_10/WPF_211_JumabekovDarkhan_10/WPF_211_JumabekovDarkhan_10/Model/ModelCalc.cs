using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_211_JumabekovDarkhan_10.Model
{
  public class ModelCalc : INotifyPropertyChanged
  {
    public string displayText { get; set; }
    public string historyText { get; set; }

    public bool isResult { get; set; }

    public string DisplayText {
      get { return displayText; }
      set {
        displayText = value;
        OnPropertyChanged("DisplayText");
      }
    }

    public string HistoryText {
      get { return historyText; }
      set {
        historyText = value;
        OnPropertyChanged("HistoryText");
      }
    }

    public bool IsResult {
      get { return isResult; }
      set {
        isResult = value;
        OnPropertyChanged("DisplayText");
      }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "")
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
  }
}
