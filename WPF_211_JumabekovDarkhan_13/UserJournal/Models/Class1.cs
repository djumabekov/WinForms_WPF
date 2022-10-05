using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserJournal.Models
{
    public partial class Class1 : INotifyPropertyChanged
    {
        private string someText;

        public string SomeText
        {
            get => someText;
            set
            {
                someText = value;
                PropertyChanged?
                    .Invoke(this
                    , new PropertyChangedEventArgs("SomeText"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
