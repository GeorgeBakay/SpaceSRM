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
    public class EditEmployerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

 
        readonly IEmployer employerConnection = new EmployerRepository();
        ObservableCollection<Employer> employers;

        bool _isBusy = true;
        
        public Employer SelectedItem { get; set; }
        string thisName = "";
        string thisSurName = "";
        string thisPhone = "";
        int thisId = -1;

        string statusDel = "";
        string statusEdit = "";

        public ObservableCollection<Employer> Employers
        {
            get => employers;
            set
            {
                if (employers != value)
                {
                    employers = value;
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
            List<Employer> list = await employerConnection.GetEmployersQuick();
            if (list == null)
            {
                list = new List<Employer>();
            }
            Employers = new ObservableCollection<Employer>(list);
            IsBusy = false;
        }


        public ICommand SelectionChanged => new Command<Employer?>(p => {
            ThisId = (int)p?.Id;
            ThisName = p?.Name;
            ThisSurName = p?.SurName;
            ThisPhone = p?.Phone;
        });

        public ICommand DeleteEmployer => new Command(async () => {
            bool check = await Application.Current.MainPage.DisplayAlert("Підтвердження", $"Ви точно хочете видалити {ThisName}?", "так", "ні");
            if (!check)
            {
                return;
            }
            string response = await employerConnection.DeleteEmployer(thisId);
            if (response == "ok")
            {
                IsBusy = true;
                List<Employer> list = await employerConnection.GetEmployersQuick();
                Employers = new ObservableCollection<Employer>(list);
                IsBusy = false;
            }
            else
            {
                StatusDel = response;
            }
        });
        public ICommand EditEmployer => new Command(async () => {
            {
                if (ThisName == "" || ThisSurName == "" || ThisPhone == "")
                {
                    StatusEdit = "Некоректні значення";
                    return;
                }
                Employer thisEmployer = new Employer()
                {
                    Id = ThisId,
                    Name = ThisName,
                    SurName = ThisSurName,
                    Phone = ThisPhone,
                };
                string response = await employerConnection.EditEmployer(thisEmployer);
                if (response == "ok")
                {
                    IsBusy = true;
                    List<Employer> list = await employerConnection.GetEmployersQuick();
                    Employers = new ObservableCollection<Employer>(list);
                    IsBusy = false;
                }
                else
                {
                    StatusEdit = response;
                }
            }
        });

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
