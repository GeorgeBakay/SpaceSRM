using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Data;
namespace SpaceSRM.ViewModels
{
    public class ClientView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public int CountRecord { get; set; }
        public List<Record> Records{get;set;} = new List<Record>();
    }
    public class RecordVisual
    {
        public string Brand { get; set; }
        public string NumberOfCar { get; set; }
        public DateTime DateEnd { get; set; }
        public float Sum { get; set; }
        public List<Work> Works { get; set; } = new List<Work>();
       
    }
    public class StatisticClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly IClient clientConnection = new ClientRepository();

        ClientView selectClient;


        ObservableCollection<ClientView> clients = new ObservableCollection<ClientView>();
        List<ClientView> clientsData = new List<ClientView>();
        List<Client> stackClients = new List<Client>();
        ObservableCollection<RecordVisual> recordsVisual = new ObservableCollection<RecordVisual>();


        
        DateTime dateTo = DateTime.Today;
        DateTime dateFrom = DateTime.Today.AddMonths(-1);
        float profit = 0;
        float worksCount = 0;
        float recordsCount = 0;
        public ObservableCollection<RecordVisual> RecordsVisual
        {
            get => recordsVisual;
            set
            {
                recordsVisual = value;
                OnPropertyChanged();
            }
        }
        public float Profit
        {
            get => profit;
            set
            {
                profit = value;
                OnPropertyChanged();
            }
        }
        public float WorksCount
        {
            get => worksCount;
            set
            {
                worksCount = value;
                OnPropertyChanged();
            }
        }
        public float RecordsCount
        {
            get => recordsCount;
            set
            {
                recordsCount = value;
                OnPropertyChanged();
            }
        }
        bool _isBusy = true;
        public ClientView SelectClient
        {
            get => selectClient;
            set
            {
                if(value != selectClient)
                {
                    selectClient = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateFrom
        {
            get => dateFrom;
            set
            {
                dateFrom = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateTo
        {
            get => dateTo;
            set
            {
                dateTo = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ClientView> Clients
        {
            get => clients;
            set
            { 
                clients = value;
                OnPropertyChanged();  
            }
        }
        public ObservableCollection<ISeries> SeriesWorks { get; set; } = new ObservableCollection<ISeries>()
        {
            new PolarLineSeries<int>
            {
                Values = new ObservableCollection<int>(),
                LineSmoothness = 1,
                GeometrySize= 0,
                Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90)),
                DataLabelsSize = 5,
            },
        };
        public PolarAxis[] AngleAxes { get; set; } =
        {
            new PolarAxis
            {
                LabelsRotation = LiveCharts.TangentAngle,
                Labels = new ObservableCollection<string>(),
                TextSize = 30,
                LabelsBackground = LiveChartsCore.Drawing.LvcColor.FromRGB(25,25,25),
                LabelsPaint =new SolidColorPaint { Color = SKColors.White }
            }
        };
        public async Task LoadingData()
        {
            IsBusy = true;
            stackClients = await clientConnection.GetClients();
            clientsData = new List<ClientView>();
            foreach (Client cli in stackClients)
            {
                clientsData.Add(new ClientView()
                {
                    Id = cli.Id,
                    Name = cli.Name,
                    SurName = cli.SurName,
                    Phone = cli.Phone,
                    CountRecord = cli.Records.Count,
                    Records = cli.Records.ToList(),
                });
            }
            clientsData = clientsData.OrderByDescending(u => u.CountRecord).ToList();

            IsBusy = false;
        }
        public void VisualLoading()
        {
            Profit = 0;
            WorksCount = 0;
            RecordsCount = 0;
            Dictionary<string, int> visualWorks = new Dictionary<string, int>();
            bool conteins;
            foreach (Record record in SelectClient.Records)
            {
                if (DateFrom.Date <= record.DateEnd.Date && record.DateEnd.Date <= DateTo.Date && record.Status == Status.End)
                {
                    RecordVisual thisRecord = new RecordVisual() { 
                        Brand = record.Brand,
                        NumberOfCar = record.NumberOfCar,
                        DateEnd = record.DateEnd,
                        Sum = record.Sum,
                    };
                    
                    RecordsCount += 1;
                    Profit += record.Sum;
                    WorksCount += record.Works.Count;
                    foreach(Work work in record.Works)
                    {
                        conteins = visualWorks.ContainsKey(work.Service.Name);
                        thisRecord.Works.Add(new Work()
                        {
                            Service = work.Service,
                            Price = work.Price,
                        });
                        if (conteins)
                        {
                            visualWorks[work.Service.Name] = visualWorks[work.Service.Name] + work.Price;
                        }
                        else
                        {
                            visualWorks.TryAdd(work.Service.Name, work.Price);
                        }
                    }
                    RecordsVisual.Add(thisRecord);
                }   
            }
            foreach (var work in visualWorks)
            {
                AngleAxes[0].Labels.Add(work.Key);
                ((ObservableCollection<int>)SeriesWorks[0].Values).Add(work.Value);
            }
        }
        public void VisualClients()
        {
            Clients = new ObservableCollection<ClientView>(clientsData);
        }
        public void ClearClients()
        {
            Clients = new ObservableCollection<ClientView>();
            OnPropertyChanged();
        }

        public void ClearVisual()
        {
            AngleAxes[0].Labels = new ObservableCollection<string>();
            SeriesWorks[0].Values = new ObservableCollection<int>();
            RecordsVisual = new ObservableCollection<RecordVisual>();
            OnPropertyChanged();
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
