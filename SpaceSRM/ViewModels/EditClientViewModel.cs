using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceSRM.ViewModels
{
    public class EditClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        readonly IClient client = new ClientRepository();
        ObservableCollection<Client> clients;
        
        bool _isBusy = true;
        bool _isBusyEdit = false;
        public Client SelectedItem { get; set; }
        string thisName = "";
        string thisSurName = "";
        string thisPhone = "";
        int thisId = -1;

        string statusDel = "";
        string statusEdit = "";
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                if(clients != value)
                {
                    clients = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StatusEdit
        {
            get => statusEdit;
            set
            {
                statusEdit = value;
                OnPropertyChanged();
            }
        }
        public string StatusDel
        {
            get => statusDel;
            set
            {
                statusDel = value;
                OnPropertyChanged();
            }
        }
        public int ThisId
        {
            get => thisId;
            set => thisId = value;
        }
        public string ThisName
        {
            get => thisName;
            set
            {
                if (thisName != value)
                {
                    thisName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ThisSurName
        {
            get => thisSurName;
            set
            {
                if (thisSurName != value)
                {
                    thisSurName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ThisPhone
        {
            get => thisPhone;
            set
            {
                if (thisPhone != value)
                {
                    thisPhone = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsBusyEdit
        {
            get => _isBusyEdit;
            set
            {
                if (_isBusyEdit != value)
                {
                    _isBusyEdit = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }


        public async Task LoadingData()
        {

            IsBusy = true;
            List<Client> list = await client.GetClientsQuick();
            if(list == null)
            {
                list = new List<Client>();
            }
            Clients = new ObservableCollection<Client>(list);
            IsBusy = false;
        }
        public void DisLoadingData()
        {
            Clients = new ObservableCollection<Client>();       
        }


        public ICommand SelectionChanged => new Command<Client?>(p => {
            ThisId = (int)p?.Id;
            ThisName = p?.Name;
            ThisSurName = p?.SurName;
            ThisPhone = p?.Phone;
        });

        public ICommand DeleteClient => new Command(async () => {
            IsBusyEdit = true;
            bool check = await Application.Current.MainPage.DisplayAlert("Підтвердження", $"Ви точно хочете видалити {ThisName}?", "так", "ні");
            if (!check)
            {
                return;
            }
            string response = await client.DeleteClient(thisId);
            if (response == "ok")
            {
                IsBusy = true;
                List<Client> list = await client.GetClientsQuick();
                Clients = new ObservableCollection<Client>(list);
                StatusDel = "Дання успішно видалені";
                IsBusy = false;
            }
            else
            {
                StatusDel = response;
            }
            IsBusyEdit = false;
        });
        public ICommand EditClient => new Command(async () => {
            
                IsBusyEdit = true;
                if (ThisName == "" || ThisSurName == "" || ThisPhone == "")
                {
                    StatusEdit = "Некоректні значення";
                    return;
                }
                Client thisClient = new Client()
                {
                    Id = ThisId,
                    Name = ThisName,
                    SurName = ThisSurName,
                    Phone = ThisPhone,
                };
                string response = await client.EditClient(thisClient);
                if (response == "ok")
                {
                    IsBusy = true;
                    List<Client> list = await client.GetClientsQuick();
                    Clients = new ObservableCollection<Client>(list);
                    StatusEdit = "Данні успішно змінені";
                    IsBusy = false;

                }
                else
                {
                    StatusEdit = response;
                }
            
            IsBusyEdit = true;
        });
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
