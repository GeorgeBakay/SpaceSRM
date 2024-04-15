
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
    public class EditSetServiceViewModel : INotifyPropertyChanged
    {
        private readonly ISetService setService = new SetServiceRepository();
        private readonly IService service = new ServiceRepository();
        public event PropertyChangedEventHandler PropertyChanged;
        //public List<Service> checkedService { get; set; }
        //Поля SetServiceViewModel
        //список Наборів
        ObservableCollection<SetService> setServices;
        //Стан загрузки
        bool _isBusy = true;
        //Поточний вибраний
        SetService SelectedItem { get; set; }
        //Поля поточного вибраного
        int thisId = -1;
        string thisName = "";
        List<Service> thisServices;
        int thisDiscount;

        //вибір послуги при додаванні
        List<Service> checkServices;

        //Додавання нового елемента поля
        string addName = "";
        List<Service> addServices;
        int addDiscount;

        string statusDel = "";
        string statusEdit = "";



        //Кінец поля SetServiceViewModel


        //Доступ до полів класу 


        public int ThisId
        {
            get => thisId;
            set => thisId = value;
        }
        public string StatusEdit
        {
            get => statusEdit;
            set=> statusEdit = value;
        }
        public string StatusDel
        {
            get => statusDel;
            set => statusDel = value;
        }



        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if(value != _isBusy)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<SetService> SetServices
        {
            get => setServices;
            set
            {
                if(setService != value)
                {
                    setServices = value;
                    OnPropertyChanged();
                }
            }
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
        public List<Service> ThisServices
        {
            get => thisServices;
            set
            {
                if(value != thisServices)
                {
                    thisServices = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ThisDiscount
        {
            get => thisDiscount;
            set
            {
                if(value != thisDiscount)
                {
                    thisDiscount = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<Service> CheckServices
        {
            get => checkServices;
            set
            {
                if (checkServices != value)
                {
                    checkServices = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AddName
        {
            get => addName;
            set
            {
                if (addName != value)
                {
                    addName = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<Service> AddServices
        {
            get => addServices;
            set
            {
                if (value != addServices)
                {
                    addServices = value;
                    OnPropertyChanged();
                }
            }
        }
        public int AddDiscount
        {
            get => addDiscount;
            set
            {
                if (value != addDiscount)
                {
                    addDiscount = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task LoadingData()
        {

            IsBusy = true;
            List<SetService> list = await setService.GetSetServices();
            if (list == null)
            {
                list = new List<SetService>();
            }
            SetServices = new ObservableCollection<SetService>(list);

            IsBusy = false;
        }
        public async Task LoadingServicesData()
        {

            IsBusy = true;
            List<Service> list = await service.GetServicesQuick();
            if (list == null)
            {
                list = new List<Service>();
            }
            CheckServices = list;

            IsBusy = false;
        }

        public ICommand SelectionChanged => new Command<SetService?>(p => {
            ThisId = p.Id;
            ThisName = p.Name;
            ThisServices = p.Services.ToList();
            ThisDiscount = p.Discount;
        });


        public ICommand EditService => new Command(async () => {
            

            if ((ThisDiscount < 0) || (ThisDiscount > 100)
            || ThisName == null || ThisName == "" )
            {
                StatusEdit = "Некоректні значення";
            }

            else
            {
                SetService thisSetService = new SetService()
                {
                    Id = ThisId,
                    Name = ThisName,
                    Services = ThisServices,
                    Discount = ThisDiscount,
                    

                };
                string response = await setService.EditSetService(thisSetService);
                if (response == "ok")
                {
                    IsBusy = true;
                    List<SetService> list = await setService.GetSetServices();
                    SetServices = new ObservableCollection<SetService>(list);
                    IsBusy = false;
                }
                else
                {
                    StatusEdit = response;
                }
            }


        });
        public ICommand DeleteService => new Command(async () => {
            bool check = await Application.Current.MainPage.DisplayAlert("Підтвердження", $"Ви точно хочете видалити {ThisName} обєкт?", "так", "ні");
            if (!check)
            {
                return;
            }
            string response = await setService.DeleteSetService(ThisId);
           

            if (response == "ok")
            {
                IsBusy = true;
                List<SetService> list = await setService.GetSetServices();
                SetServices = new ObservableCollection<SetService>(list);
                IsBusy = false;
            }
            else
            {
                StatusDel = response;
            }
        });

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
