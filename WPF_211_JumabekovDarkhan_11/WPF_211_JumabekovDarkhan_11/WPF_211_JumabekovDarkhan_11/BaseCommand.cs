using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_211_JumabekovDarkhan_11
{
  public class BaseCommand : ICommand
  {
    private Action<object> execute;

    public BaseCommand(Action<object> execute)
    {
      this.execute = execute;
    }

    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove {
        CommandManager.RequerySuggested -= value;
      }
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      try
      {
        execute(parameter);
      }
      catch (Exception)
      {

      }
    }
  }
}
