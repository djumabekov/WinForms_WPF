using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserJournal.Models;

namespace UserJournal.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Root rootItem;
        private string userCount;
        private bool isLoading;
        private Result selectedItem;
      

    public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(
            [CallerMemberName] string pName = "")
        {
            PropertyChanged?
                .Invoke(this
                , new PropertyChangedEventArgs(pName));
        }

        public Root RootItem
        {
            get => rootItem;
            set
            {
                rootItem = value;
                OnPropertyChanged();
            }
        }

        public string UserCount
        {
            get => userCount;
            set
            {
                userCount = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        public BaseCommand SaveCmd { get; set; }

        public Result SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Init();
            SaveCmd = new BaseCommand(SaveToFile);
     
    }
   

    private void SaveToFile(object obj)
        {
            var jsonContent = JsonConvert.SerializeObject(SelectedItem, Formatting.Indented);
            File.WriteAllText("myFile.txt", jsonContent);
            MessageBox.Show("File wrote succesfully");
        }

        private async void Init()
        {
            HttpClient client =
                (HttpClient)App.Current.Properties["httpClient"];
            IsLoading = true;
            await Task.Delay(2000);
            var responce = await client.GetAsync("https://randomuser.me/api/?seed=foobar&results=10");
            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                RootItem = JsonConvert.DeserializeObject<Root>(content);
                UserCount = $"Users({RootItem.results.Count})";
            }
            IsLoading = false;
        }
    }
}
