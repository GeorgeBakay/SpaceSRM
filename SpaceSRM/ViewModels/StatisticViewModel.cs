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
    public class StatisticViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly IRecord recordConnection = new RecordRepository();
        readonly IClient clientConnection = new ClientRepository();
        
        readonly IService serviceConnection = new ServiceRepository();

        
        List<Record> records = new List<Record>();
        List<Client> clients = new List<Client>();
        List<Work> works = new List<Work>();
        List<Service> services = new List<Service>();

        ObservableCollection<Work> worksVisual = new ObservableCollection<Work>();

        float progressBar = 0;
        bool visableBar = true;

        DateTime dateFrom = DateTime.Today.AddMonths(-1);
        DateTime dateTo = DateTime.Now;



        //For Modeling Chart
          //Chart Record
        public ObservableCollection<ISeries> SeriesRecord { get; set; } = new ObservableCollection<ISeries>
        {
            new ColumnSeries<DateTimePoint>
            {
                TooltipLabelFormatter = (chartPoint) =>
                    $"{new DateTime((long) chartPoint.SecondaryValue):yyyy MM dd}: {chartPoint.PrimaryValue}",
                Values = new ObservableCollection<DateTimePoint>(),

                MaxBarWidth = double.MaxValue,
                DataLabelsSize = 10,
                Fill = new SolidColorPaint(new SKColor(84,138,254)),
                
            }
        };
        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                TextSize = 20,
                Labeler = value => new DateTime((long) value).ToString("yyyy MM dd"),
                LabelsRotation = 50,
                UnitWidth = TimeSpan.FromDays(1).Ticks, 
                MinStep = TimeSpan.FromDays(1).Ticks,

                MaxLimit = DateTime.Now.Ticks,
                MinLimit = DateTime.Now.Ticks -TimeSpan.FromDays(15).Ticks
            }
        };

        //Chart Works
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
            TextSize = 40,
            LabelsBackground = LiveChartsCore.Drawing.LvcColor.FromRGB(25,25,25),
            LabelsPaint =new SolidColorPaint { Color = SKColors.White }
        }
    };
      

        public ObservableCollection<Work> WorksVisual
        {
            get => worksVisual;
            set
            {
                worksVisual = value;
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

        public bool VisableBar
        {
            get => visableBar;
            set
            {
                visableBar = value;
                OnPropertyChanged();
            }
        }
    
        public float ProgressBar
        {
            get => progressBar;
            set
            {
                progressBar = value;
                OnPropertyChanged();
            }
        }
        //Loading All Data From Server
        public async Task LoadingData()
        {
            VisableBar = true;
            ProgressBar = 0.1f;
            records = await recordConnection.GetRecords();
            ProgressBar = 0.2f;
            foreach(Record record in records)
            {
                foreach(Work work in record.Works)
                {
                    work.Record = new Record();
                    work.Record.DateEnd = record.DateEnd;
                    works.Add(work);
                }
                
            }
            ProgressBar = 0.3f;

            
            List<DateTimePoint> datesRecords = new List<DateTimePoint>();
            foreach(Record record in records)
            {
                DateTimePoint thisDate = datesRecords.Where(u => u.DateTime.Year == record.DateEnd.Year 
                && u.DateTime.Month == record.DateEnd.Month 
                && u.DateTime.Day == record.DateEnd.Day).FirstOrDefault();
                if(thisDate != null)
                {
                    thisDate.Value += record.Sum;
                }
                else
                {
                    datesRecords.Add(new DateTimePoint(new DateTime(record.DateEnd.Year,
                        record.DateEnd.Month,
                        record.DateEnd.Day), record.Sum));
                }

            }
            ProgressBar = 0.7f;
            foreach (DateTimePoint point in datesRecords)
            {
                ((ObservableCollection<DateTimePoint>)SeriesRecord[0].Values).Add(point);
            }
            

            ProgressBar = 1;
            VisableBar = false;
        }
        
        public void VisualWorksStats()
        {

            
            Dictionary<string, int> visualWorks = new Dictionary<string, int>();
            bool conteins;
            foreach(Work work in works)
            {
                if(DateFrom <= work.Record.DateEnd && work.Record.DateEnd <= DateTo)
                {
                    conteins = visualWorks.ContainsKey(work.Service.Name);
                    if (conteins)
                    {
                        visualWorks[work.Service.Name] = visualWorks[work.Service.Name] + work.Price;
                    }
                    else
                    {
                        visualWorks.TryAdd(work.Service.Name, work.Price);
                    }
                }
            }
            AngleAxes[0].Labels = new ObservableCollection<string>();
            SeriesWorks[0].Values = new ObservableCollection<int>();

            foreach (var work in visualWorks)
            {
                AngleAxes[0].Labels.Add(work.Key);
                ((ObservableCollection<int>)SeriesWorks[0].Values).Add(work.Value);
            }
            


        }
        public void VisualWorksList()
        {
            foreach (Work work in works)
            {
                if (DateFrom < work.Record.DateEnd && work.Record.DateEnd < DateTo)
                {
                    WorksVisual.Add(work);
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
