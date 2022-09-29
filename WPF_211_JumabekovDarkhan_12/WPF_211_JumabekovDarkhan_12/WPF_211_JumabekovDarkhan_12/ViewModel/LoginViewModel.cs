using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_211_JumabekovDarkhan_12.Model;

namespace WPF_211_JumabekovDarkhan_12.ViewModel
{

  
  public class LoginViewModel : INotifyPropertyChanged
  {
    LoginModel loginModel { get; set; }


    public BaseCommand LoginCmd { get; set; }
    public BaseCommand GoSocialMediaCmd { get; set; }

    public LoginViewModel()
    {
      loginModel = new LoginModel();
      LoginCmd = new BaseCommand(Login);
      GoSocialMediaCmd = new BaseCommand(GoSocialMedia);
    }

    private void Login(object obj)
    {
      MessageBox.Show(loginModel.ToString(), "Приветствие", MessageBoxButton.OK, MessageBoxImage.None);
    }
    private void GoSocialMedia(object obj)
    {
      Process.Start(new ProcessStartInfo((string)obj) { UseShellExecute = true });
    }

    public string FullName {
      get { return loginModel.FullName; }
      set {
        loginModel.FullName = value;
        OnPropertyChanged("FullName");
      }
    }
    public string Email {
      get { return loginModel.Email; }
      set {
        loginModel.Email = value;
        OnPropertyChanged("Email");
      }
    }
    public string Phone {
      get { return loginModel.Phone; }
      set {
        loginModel.Phone = value;
        OnPropertyChanged("Phone");
      }
    }
    public string Password {
      get { return loginModel.Password; }
      set {
        loginModel.Password = value;
        OnPropertyChanged("Password");
      }
    }
    public string Website {
      get { return loginModel.Website; }
      set {
        loginModel.Website = value;
        OnPropertyChanged("Website");
      }
    }
    public bool AcceptRules {
      get { return loginModel.AcceptRules; }
      set {
        loginModel.AcceptRules = value;
        OnPropertyChanged("AcceptRules");
      }
    }
    public List<string> SocialMediaLinks {
      get { return loginModel.SocialMediaLinks; }
      set {
        loginModel.SocialMediaLinks = value;
        OnPropertyChanged("SocialMediaLinks");
      }
    }
  
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string prop = "")
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

    public override string ToString()
    {
      return $"FullName: {FullName} \nEmail: {Email} \nPhone: {Phone} \nPassword {Password} \nWebsite: {Website} \nAccept Rules: {AcceptRules}";
    }
  }
}
