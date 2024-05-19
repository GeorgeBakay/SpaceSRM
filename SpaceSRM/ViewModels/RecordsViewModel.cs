using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Models;
using SpaceSRM.Date.Repository;
using SpaceSRM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace SpaceSRM.ViewModels
{
    public class RecordsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly IRecord recordConnection = new RecordRepository();
        readonly IClient clientConnection = new ClientRepository();
        readonly IEmployer employerConnection = new EmployerRepository();
        readonly IService serviceConnection = new ServiceRepository();
        //Внутнрішні поля для зберігання данних
        List<Work> worksData = new List<Work>();
        List<Client> clientsData = new List<Client>();
        List<Employer> employersData= new List<Employer>();
        List<Service> servicesData = new List<Service>();

        //Внутрішні поля для візуалізації
        ObservableCollection<Record> records = new ObservableCollection<Record>();
        ObservableCollection<Client> clients = new ObservableCollection<Client>();
        ObservableCollection<Work> works = new ObservableCollection<Work>();
        ObservableCollection<Employer> employers;
        ObservableCollection<Service> services;

        ObservableCollection<CustomPhoto> photoAfterPrevious = new ObservableCollection<CustomPhoto>();
        ObservableCollection<CustomPhoto> photoBeforePrevious = new ObservableCollection<CustomPhoto>();


        ObservableCollection<CustomPhoto> photoAfter = new ObservableCollection<CustomPhoto>();
        ObservableCollection<CustomPhoto> photoBefore = new ObservableCollection<CustomPhoto>();


        bool _isBusy = true;
        bool _isBusyClient = true;
        bool _isBusyPhoto = true;
        bool _isBusyEmployer = true;
        bool _isBusyService = true;
        Record addRecord = new Record();


        float sum = 0;
        Client selectClient = new Client();
        Service selectService = new Service();
        List<Employer> selectEmployers = new List<Employer>();
        Work selectWork;
        Record selectRecord;

        TimeSpan timeBefore = new TimeSpan();
        TimeSpan timeAfter = new TimeSpan();

        CustomPhoto selectPhoto = new CustomPhoto();

        int statusWork= 0;
        int discountWork = 0;


        public List<Service> ServicesData
        {
            get => servicesData;
            set
            {
                servicesData = value;
            }
        }
        public List<Employer> EmployersData
        {
            get => employersData;
            set
            {
                employersData = value;
            }
        }
        public List<Client> ClientsData
        {
            get => clientsData;
            set
            {
                clientsData = value;
            }
        }
        public List<Work> WorksData
        {
            get => worksData;
            set
            {
                worksData = value;
            }
        }
        public Work SelectWork
        {
            get => selectWork;
            set
            {
                selectWork = value;
                OnPropertyChanged();
            }
        }
        public CustomPhoto SelectPhoto
        {
            get => selectPhoto;
            set
            {
                selectPhoto = value;
                OnPropertyChanged();
            }
        }
        public int DiscountWork
        {
            get => discountWork;
            set
            {
                discountWork = value;
                OnPropertyChanged();
            }
        }

        public int StatusWork
        {
            get => statusWork;
            set
            {
                statusWork = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan TimeBefore
        {
            get => timeBefore;
            set
            {
                timeBefore = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan TimeAfter
        {
            get => timeAfter;
            set
            {
                timeAfter = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusyEmployer
        {
            get => _isBusyEmployer;
            set
            {
                _isBusyEmployer = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusyService
        {
            get => _isBusyService;
            set
            {
                _isBusyService = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusyPhoto
        {
            get => _isBusyPhoto;
            set
            {
                _isBusyPhoto = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CustomPhoto> PhotoBeforePrevious
        {
            get => photoBeforePrevious;
            set
            {
                photoBeforePrevious = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CustomPhoto> PhotoAfterPrevious
        {
            get => photoAfterPrevious;
            set
            {
                photoAfterPrevious = value;
                OnPropertyChanged();
            }
        }
        public Record SelectRecord
        {
            get => selectRecord;
            set
            {
                selectRecord = value;
                OnPropertyChanged(nameof(Record));
            }
        }



        public float Sum
        {
            get => sum;
            set
            {
                sum = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CustomPhoto> PhotoAfter
        {
            get => photoAfter;
            set
            {
                photoAfter = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CustomPhoto> PhotoBefore
        {
            get => photoBefore;
            set
            {
                photoBefore = value;
                OnPropertyChanged();
            }
        }

        public Record AddRecord
        {
            get => addRecord;
            set
            {
                addRecord = value;
                OnPropertyChanged();
            }
        }
        public Service SelectService
        {
            get => selectService;
            set {
                selectService = value;
                OnPropertyChanged();
            }
        }
        public List<Employer> SelectEmployers
        {
            get => selectEmployers;
            set {
                selectEmployers = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Service> Services
        {
            get => services;
            set {
                services = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Employer> Employers
        {
            get => employers;
            set {
                employers = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Work> Works
        {
            get => works;
            set {
                works = value;
                OnPropertyChanged();
            }
        }


        public Client SelectClient
        {
            get => selectClient;
            set
            {
                selectClient = value;
                OnPropertyChanged();
            }
        }


        //Get методи
        public ObservableCollection<Record> Records
        {
            get => records;
            set
            {
                if (value != records)
                {
                    records = value;
                    OnPropertyChanged(nameof(Records));
                }
            }
        }
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (value != _isBusy)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }
        public bool IsBusyClient
        {
            get => _isBusyClient;
            set
            {
                if (value != _isBusyClient)
                {
                    _isBusyClient = value;
                    OnPropertyChanged(nameof(IsBusyClient));
                }
            }
        }
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {

                clients = value;
                OnPropertyChanged();

            }
        }

        //Методи і команди
        public void ClearVisualWorks()
        {
            Works = new ObservableCollection<Work>();
        }
        public void VisualDataWorks()
        {
            Works = new ObservableCollection<Work>(WorksData);
        }
        public async Task LoadingDataEmployers()
        {
            IsBusyEmployer = true;
            EmployersData = await employerConnection.GetEmployersQuick();
            

            IsBusyEmployer = false;
        }
        public void VisualDataEmployers()
        {
            if (EmployersData == null)
            {
                EmployersData = new List<Employer>();
            }
            Employers = new ObservableCollection<Employer>(EmployersData);
            IsBusyEmployer = false;
        }
        public void ClearVisualEmployers()
        {
            Employers = new ObservableCollection<Employer>();
        }
        public async Task LoadingDataServices()
        {
            IsBusyService = true;
            ServicesData = await serviceConnection.GetServicesQuick();
            

            IsBusyService = false;
        }
        public void VisualDataServices()
        {
            if (ServicesData == null)
            {
                ServicesData = new List<Service>();
            }
            Services = new ObservableCollection<Service>(ServicesData);
            IsBusyService = false;
        }
        public void ClearVisualServices()
        {
            Services = new ObservableCollection<Service>();
        }
        public async Task LoadingDataRecords()
        {

            IsBusy = true;
            List<Record> list = await recordConnection.GetRecordsQuick();
            if (list == null)
            {
                list = new List<Record>();
            }
            foreach (Record rec in list)
            {
                Records.Add(rec);
            }


            IsBusy = false;
        }
        public async Task LoadingRecord()
        {
            Record getRec = await recordConnection.GetRecord(SelectRecord.Id);
            
            TimeBefore = getRec.DateStart.TimeOfDay;
            TimeAfter = getRec.DateEnd.TimeOfDay;
            AddRecord = getRec;
            Sum = AddRecord.Sum;
            Client thisClient = AddRecord.Client;
            Status status = AddRecord.Status;
            if (status == Status.End)
            {
                StatusWork = 2;
            }
            else if (status == Status.Work)
            {
                StatusWork = 1;
            }
            else if (status == Status.Abolition)
            {
                StatusWork = 3;
            }
            else
            {
                StatusWork = 0;
            }

            DiscountWork = AddRecord.Discount;
            Sum = AddRecord.Sum;

            SelectClient = new Client()
            {
                Name = thisClient.Name,
                SurName = thisClient.SurName,
                Id = thisClient.Id,
                Phone = thisClient.Phone
            }; 
            Work thisWork = new Work();
            foreach (Work i in AddRecord.Works)
            {
                thisWork.Id = i.Id;
                thisWork.Employers = i.Employers;
               
                thisWork.Service = i.Service;
                thisWork.ServiceId = i.Service.Id;
                thisWork.Price = i.Price;
                thisWork.TruePrice = i.TruePrice;
                i.Record = new Record();
                thisWork.Record = new Record();
                thisWork.RecordId = AddRecord.Id;
                thisWork.PriceCost = i.PriceCost;
                thisWork.DescriptionCost = i.DescriptionCost;
                WorksData.Add(thisWork);
                thisWork = new Work();
            }
            IsBusyPhoto = false;
        }
        public async Task LoadingPhoto()
        {
            if (AddRecord != null)
            {
                IsBusyPhoto = true;
                PhotoAfterPrevious = new ObservableCollection<CustomPhoto>();
                PhotoBeforePrevious = new ObservableCollection<CustomPhoto>();

                Photo photo = new Photo();
                List<Photo> listPhotos = new List<Photo>();

                for (int j = 0; j <= 100; j++)
                {
                    photo = await recordConnection.GetPhoto(AddRecord.Id, j);
                    if (photo.Bytes == null)
                    {
                        break;
                    }
                    else
                    {
                        listPhotos.Add(photo);
                    }
                }
                foreach (Photo i in listPhotos)
                {
                    switch (i.Type)
                    {
                        case PhotoType.Before:
                            PhotoBeforePrevious.Add(ByteArrayToCustomPhoto(i));
                            break;
                        case PhotoType.After:
                            PhotoAfterPrevious.Add(ByteArrayToCustomPhoto(i));
                            break;
                    }
                }

                IsBusyPhoto = false;
            }
        }
        public CustomPhoto ByteArrayToCustomPhoto(Photo photo)
        {
            var memoryStream = new MemoryStream(photo.Bytes);
            memoryStream.Position = 0;
            CustomPhoto image = new CustomPhoto();

            Photo AddPhoto = new Photo();
            AddPhoto.Bytes = memoryStream.ToArray();
            AddPhoto.FileExtention = photo.FileExtention;
            AddPhoto.Size = memoryStream.Length;
            AddPhoto.Type = photo.Type;
            AddPhoto.Id = photo.Id;


            var sourceimage = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
            image.ImageC.Source = sourceimage;
            image.photo = AddPhoto;
            return image;

        }
        public async Task VisualDataClients()
        {
            if (ClientsData == null)
            {
                ClientsData = new List<Client>();
            }
            else
            {
                foreach (Client cli in ClientsData)
                {
                    Clients.Add(cli);
                }
            }

        }
        public async Task LoadingDataClients()
        {
            IsBusyClient = true;
            ClientsData = await clientConnection.GetClientsQuick();
            ClientsData = ClientsData.OrderByDescending(u => u.Id).ToList();
            IsBusyClient = false;
        }
        public void ClearVisualClients()
        {
            Clients = new ObservableCollection<Client>();
        }
        public async Task DeletePhoto(CustomPhoto photo)
        {
            await recordConnection.DeletePhoto(photo.photo.Id);
        }
        public async Task DeleteRecord(Record thisRecord)
        {
            await recordConnection.DeleteRecord(thisRecord.Id);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
