
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
    public class EditServiceViewModel : INotifyPropertyChanged
    {
        readonly IService service = new ServiceRepository();
        public event PropertyChangedEventHandler PropertyChanged;

        bool _isBusy = true;
        ObservableCollection<Service> services;
        public Service SelectedItem { get; set; }
        string thisName = "";
        string thisType = "";
        string thisPrice = "";
        string thisProcent = "";
        int thisId = -1;

        string statusDel = "";
        string statusEdit = "";


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
        public int ThisId {
            get => thisId; 
            set => thisId = value;
        }
        public string ThisName
        {
            get => thisName;
            set
            {
                if(thisName != value)
                {
                    thisName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ThisType
        {
            get => thisType;
            set
            {
                if (thisType != value)
                {
                    thisType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ThisPrice
        {
            get => thisPrice;
            set
            {
                if (thisPrice != value)
                {
                    thisPrice = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ThisProcent
        {
            get => thisProcent;
            set
            {
                if (thisProcent != value)
                {
                    thisProcent = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Service> Services
        {
            get => services;
            set
            {
                if(services != value)
                {
                    services= value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsBusy
        {
            get => _isBusy;
            set{
                if(_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }
        

        public async Task LoadingData()
        {

            IsBusy = true;
            List<Service> list = await service.GetServicesQuick();
            if(list == null)
            {
                list = new List<Service>();
            }
            Services = new ObservableCollection<Service>(list);

            IsBusy = false;

            
            
        }
        public async Task DisLoadingData()
        {       
            Services = new ObservableCollection<Service>();  
        }

        public ICommand SelectionChanged => new Command<Service?>(p => {
            ThisId = (int)p?.Id;
            ThisName = p?.Name;
            ThisPrice = p?.Price.ToString();
            ThisType = p?.Type;
            ThisProcent = p?.Procent.ToString();
        });


        public ICommand DeleteService => new Command(async () => {
            bool check = await Application.Current.MainPage.DisplayAlert("Підтвердження", $"Ви точно хочете видалити {ThisName} обєкт?", "так", "ні");
            if (!check)
            {
                return;
            }
            string response = await service.DeleteService(thisId);
            if(response == "ok")
            {
                IsBusy = true;
                List<Service> list = await service.GetServicesQuick();
                Services = new ObservableCollection<Service>(list);
                IsBusy = false;
            }
            else
            {
                StatusDel = response;
            }
        });

        public ICommand EditService => new Command(async () => {
            int price;
            int procent;
            if (!int.TryParse(ThisPrice, out price) || !int.TryParse(ThisProcent, out procent)
            || ThisName == null || ThisType == null || ThisName == "" || ThisType == "")
            {
                StatusEdit = "Некоректні значення";
            }
           
            else
            {
                Service thisService = new Service()
                {
                    Id = ThisId,
                    Name = ThisName,
                    Type = ThisType,
                    Price = Convert.ToInt32(ThisPrice),
                    Procent = Convert.ToInt32(ThisProcent)

                };
                string response = await service.EditService(thisService);
                if (response == "ok")
                {
                    IsBusy = true;
                    List<Service> list = await service.GetServicesQuick();
                    Services = new ObservableCollection<Service>(list);
                    IsBusy = false;
                }
                else
                {
                    StatusEdit = response;
                }
            }
            
           
        });

        //public ICommand LoadData => new Command(async () => {
        //    IsBusy = true;
        //    List<Service> list = await service.GetServices();
        //    Services = new ObservableCollection<Service>(list);

        //    IsBusy = false;
        //},() => thisId >= 0);

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



    }
}
