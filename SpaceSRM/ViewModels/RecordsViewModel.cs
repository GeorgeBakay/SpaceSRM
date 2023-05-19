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
        private readonly IRecord recordConnection = new RecordRepository();
        readonly IClient clientConnection = new ClientRepository();
        readonly IEmployer employerConnection = new EmployerRepository();
        readonly IService serviceConnection = new ServiceRepository();
        //Внутрішні поля
        ObservableCollection<Record> records;
        ObservableCollection<Client> clients;
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
        Record selectRecord;

        TimeSpan timeBefore = new TimeSpan();
        TimeSpan timeAfter = new TimeSpan();

        CustomPhoto selectPhoto = new CustomPhoto();

        int statusWork= 0;
        int discountWork = 0;


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
        public async Task LoadingDataEmployers()
        {
            IsBusyEmployer = true;
            List<Employer> list = await employerConnection.GetEmployersQuick();
            if (list == null)
            {
                list = new List<Employer>();
            }
            Employers = new ObservableCollection<Employer>(list);

            IsBusyEmployer = false;
        }
        public async Task LoadingDataServices()
        {
            IsBusyService = true;
            List<Service> list = await serviceConnection.GetServicesQuick();
            if (list == null)
            {
                list = new List<Service>();
            }
            Services = new ObservableCollection<Service>(list);

            IsBusyService = false;
        }
        public async Task LoadingDataRecords()
        {

            IsBusy = true;
            List<Record> list = await recordConnection.GetRecordsQuick();
            if (list == null)
            {
                list = new List<Record>();
            }
            Records = new ObservableCollection<Record>(list);

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
                Works.Add(thisWork);
                thisWork = new Work();
            }
            if (AddRecord != null)
            {
                IsBusyPhoto = true;


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
                foreach(Photo i in listPhotos)
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
        public async Task LoadingDataClients()
        {
            IsBusyClient = true;
            List<Client> list = await clientConnection.GetClientsQuick();
            if (list == null)
            {
                list = new List<Client>();
            }
            else
            {
                Clients = new ObservableCollection<Client>(list);
               
                //SelectClient = new Client();
                //if (clientSel != null)
                //{
                //    SelectClient = clientSel;   
                //}
            }

            

            IsBusyClient = false;
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
