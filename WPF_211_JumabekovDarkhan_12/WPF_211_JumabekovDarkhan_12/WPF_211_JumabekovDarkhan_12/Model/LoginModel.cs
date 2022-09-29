using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_211_JumabekovDarkhan_12.Model
{

 
  public class LoginModel : INotifyPropertyChanged
  {
    private string fullName;
    private string email;
    private string phone;
    private string password;
    private string website;
    private bool acceptRules;
    public List<string> SocialMediaLinks { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string prop = "")
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }


    public string FullName {
      get => fullName;
      set {
        fullName = value;
        OnPropertyChanged("FullName");
      }
    }


    public string Email {
      get => email;
      set {
        email = value;
        OnPropertyChanged("Email");
      }
    }
    public string Phone {
      get => phone;
      set {
        phone = value;
        OnPropertyChanged("Phone");
      }
    }
    public string Password {
      get => password;
      set {
        password = value;
        OnPropertyChanged("Password");
      }
    }

    public string Website {
      get => website;
      set {
        website = value;
        OnPropertyChanged("Website");
      }
    }
    public bool AcceptRules { 
      get => acceptRules;
      set {
        acceptRules = value;
        OnPropertyChanged("AcceptRules");
      }
    }

    public LoginModel()
    {
      SocialMediaLinks = new List<string> {
        "https://facebook.com",
        "https://twitter.com",
        "https://youtube.com",
        "https://linkedin.com"
      };
    }

    public override string ToString()
    {
      return $"FullName: {FullName} \nEmail: {Email} \nPhone: {Phone} \nPassword {Password} \nWebsite: {Website} \nAccept Rules: {AcceptRules}";
    }

  }
}
