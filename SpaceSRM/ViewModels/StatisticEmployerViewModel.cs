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
    public class VisualWorksOfEmployer
    {
        public string Brand { get; set; } = "";
        public string Name { get; set; } = "";
        public string DateEnd { get; set; } = "";
        public int CountEmp { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int Cost { get; set; } = 0;
        public int Procent { get; set; } = 0;
        public int Salery { get; set; } = 0;
    }
    public class StatisticEmployerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly IEmployer employerConnection = new EmployerRepository();
        readonly ISalary salaryConnection = new SalaryRepository();

        List<Employer> employers = new List<Employer>();
        ObservableCollection<Employer> viewEmployers = new ObservableCollection<Employer>();
        Employer employer = new Employer();

        List<Work> works = new List<Work>();
        ObservableCollection<VisualWorksOfEmployer> worksVisual = new ObservableCollection<VisualWorksOfEmployer>();

        List<Salary> salarys = new List<Salary>();
        ObservableCollection<Salary> salarysVisual = new ObservableCollection<Salary>();
        Salary salary = new Salary() { Date = DateTime.Now, Employer = new Employer()};




        DateTime dateTo = DateTime.Today;
        DateTime dateFrom = DateTime.Today.AddMonths(-1);

        int salery = 0;
        int profit = 0;
        int worksCount = 0;
        int salaryWithOut = 0;



        public Salary Salary
        {

            get => salary;
            set
            {
                salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }
        public ObservableCollection<Salary> SalarysVisual
        {
            get => salarysVisual;
            set
            {
                salarysVisual = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<VisualWorksOfEmployer> WorksVisual
        {
            get => worksVisual;
            set
            {
                worksVisual = value;
                OnPropertyChanged();
            }
        }
        public int SalaryWithOut{
            get => salaryWithOut;
            set
            {
                salaryWithOut  = value;
                OnPropertyChanged(nameof(SalaryWithOut));
            }
        }
        public int Salery
        {
            get => salery;
            set
            {
                salery = value;
                OnPropertyChanged();
            }
        }
        public int Profit
        {
            get => profit;
            set
            {
                profit = value;
                OnPropertyChanged();
            }
        }
        public int WorksCount
        {
            get => worksCount;
            set
            {
                worksCount = value;
                OnPropertyChanged();
            }
        }

        bool isBusy = true;
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
        public Employer Employer
        {
            get => employer;
            set
            {
                employer = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Employer> ViewEmployers
        {
            get => viewEmployers;
            set
            {
                viewEmployers = value;
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
                TextSize = 3,
                LabelsBackground = LiveChartsCore.Drawing.LvcColor.FromRGB(25,25,25),
                LabelsPaint =new SolidColorPaint { Color = SKColors.White }
            }
        };
        public ObservableCollection<ISeries> SeriesProfit { get; set; } = new ObservableCollection<ISeries>
        {
            new LineSeries<DateTimePoint>
            {
                TooltipLabelFormatter = (chartPoint) =>
                    $"{new DateTime((long) chartPoint.SecondaryValue):yyyy MM dd}: {chartPoint.PrimaryValue}",
                Values = new ObservableCollection<DateTimePoint>(),

                LineSmoothness = 0.6,
                Stroke = new SolidColorPaint(new SKColor(78, 209, 107)){ StrokeThickness = 12},
                Fill = null,
            },
            new LineSeries<DateTimePoint>
            {
                TooltipLabelFormatter = (chartPoint) =>
                    $"{new DateTime((long) chartPoint.SecondaryValue):yyyy MM dd}: {chartPoint.PrimaryValue}",
                Values = new ObservableCollection<DateTimePoint>(),

                LineSmoothness = 0.6,
                Stroke = new SolidColorPaint(new SKColor(250, 109, 109)){ StrokeThickness = 10},
                Fill = null,
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
                MinLimit = DateTime.Now.Ticks -TimeSpan.FromDays(7).Ticks
            }
        };


        public async Task LoadingData()
        {
            IsBusy = true;
            ViewEmployers = new ObservableCollection<Employer>();
            employers = await employerConnection.GetEmployers();
            foreach(Employer emp in employers)
            {
                ViewEmployers.Add(emp);
            }
            IsBusy = false;
        }

        public void VisualWorksStats()
        {
            if(employer.Works.Count != 0)
            {
                works = employer.Works.ToList();
            }
            
            int SaleryT = 0;
            int ProfitT = 0;
            int WorksCountT = 0;
            Dictionary<string, int> visualWorks = new Dictionary<string, int>();
            bool conteins;
            
            List<Work> workToChart = new List<Work>();
            foreach (Work work in works)
            {
                if (/*DateFrom.Date <= work.Record.DateEnd.Date && work.Record.DateEnd.Date <= DateTo.Date && */work.Employers.Count != 0 && work.Record.Status == Status.End)
                {
                    int empSalery = (int)(((work.Price - work.PriceCost) * (work.Service.Procent / 100)) / work.Employers.Count);
                    WorksVisual.Add(new VisualWorksOfEmployer()
                    {
                        Brand = work.Record.Brand,
                        Name = work.Service.Name,
                        DateEnd = work.Record.DateEnd.ToShortDateString(),
                        CountEmp = work.Employers.Count,
                        Price = work.Price,
                        Procent = (int)work.Service.Procent,
                        Salery = empSalery,
                        Cost = work.PriceCost,
                    });
                    conteins = visualWorks.ContainsKey(work.Service.Name);
                    workToChart.Add(work);
                    SaleryT = SaleryT + empSalery;
                    ProfitT = ProfitT + work.Price;
                    WorksCountT++;
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
            Salery = SaleryT;
            Profit = ProfitT;
            WorksCount = WorksCountT;
            int TSalaryWithOut = SaleryT;
            employer.Salaries = employer.Salaries.OrderByDescending(u => u.Date).ToList();
            foreach (Salary salary in employer.Salaries)
            {
                
                    TSalaryWithOut -= salary.Value;
                    SalarysVisual.Add(salary);
                
            }
            SalaryWithOut = TSalaryWithOut;
            foreach (var work in visualWorks)
            {
                AngleAxes[0].Labels.Add(work.Key);
                ((ObservableCollection<int>)SeriesWorks[0].Values).Add(work.Value);
            }
            Salery = SaleryT;
            Profit = ProfitT;
            WorksCount = WorksCountT;


            List<DateTimePoint> datesProfit = new List<DateTimePoint>();
            List<DateTimePoint> datesSalery = new List<DateTimePoint>();

            workToChart = workToChart.OrderBy(x => x.Record.DateEnd).ToList();
            foreach (Work work in workToChart)
            {
                int empSalery = (int)((work.Price * (work.Service.Procent / 100)) / work.Employers.Count);
                DateTimePoint thisDateProfit = datesProfit.Where(u => u.DateTime.Year == work.Record.DateEnd.Year
                && u.DateTime.Month == work.Record.DateEnd.Month
                && u.DateTime.Day == work.Record.DateEnd.Day).FirstOrDefault();

                DateTimePoint thisDateSalery = datesSalery.Where(u => u.DateTime.Year == work.Record.DateEnd.Year
                && u.DateTime.Month == work.Record.DateEnd.Month
                && u.DateTime.Day == work.Record.DateEnd.Day).FirstOrDefault();

                if (thisDateProfit != null)
                {
                    thisDateProfit.Value += work.Price;
                }
                else
                {
                   
                    datesProfit.Add(new DateTimePoint(new DateTime(work.Record.DateEnd.Year,
                                        work.Record.DateEnd.Month,
                                        work.Record.DateEnd.Day),
                                        work.Price));
                }
                if(thisDateSalery != null)
                {
                    thisDateSalery.Value += empSalery;
                }
                else
                {
                    datesSalery.Add(new DateTimePoint(new DateTime(work.Record.DateEnd.Year,
                                        work.Record.DateEnd.Month,
                                        work.Record.DateEnd.Day),
                                        empSalery));
                }

            }

            foreach (DateTimePoint point in datesProfit)
            {
                ((ObservableCollection<DateTimePoint>)SeriesProfit[0].Values).Add(point);
            }
            foreach (DateTimePoint point in datesSalery)
            {
                ((ObservableCollection<DateTimePoint>)SeriesProfit[1].Values).Add(point);
            }
        }
        public async Task UpdateSalary()
        {
            List<Salary> dataSalary = await salaryConnection.GetSalarysEmployer(employer.Id);
            dataSalary = dataSalary.OrderByDescending(u => u.Date).ToList();
            salarys = new List<Salary>();
            SalaryWithOut = Salery;
            foreach(Salary salary in dataSalary)
            {
                if (DateFrom.Date <= salary.Date.Date && salary.Date.Date <= DateTo.Date)
                {
                    SalaryWithOut -= salary.Value;
                    salarys.Add(salary);
                }
                    
            }
            SalarysVisual = new ObservableCollection<Salary>(salarys);
        }
        public async Task AddSalary()
        {
            Salary.EmployerId = employer.Id;
            Salary.Employer  = new Employer(); 
            string result = await salaryConnection.AddSalary(Salary);
        }
        public async Task DeleteSalary()
        {
            int Id = Salary.Id;
            if (Id >= 0)
            {
                string result = await salaryConnection.DeleteSalary(Id);
            }
        }
        public async Task EditSalary()
        {
            if (Salary.Id >= 0)
            {
                string result = await salaryConnection.EditSalary(Salary);
            }
        }
        public void ClearVisual()
        {
            AngleAxes[0].Labels = new ObservableCollection<string>();
            SeriesWorks[0].Values = new ObservableCollection<int>();
            SeriesProfit[0].Values = new ObservableCollection<DateTimePoint>();
            SeriesProfit[1].Values = new ObservableCollection<DateTimePoint>();
            WorksVisual = new ObservableCollection<VisualWorksOfEmployer>();
            SalarysVisual = new ObservableCollection<Salary>();
            Dictionary<string, int> visualWorks = new Dictionary<string, int>();
        }
        

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
