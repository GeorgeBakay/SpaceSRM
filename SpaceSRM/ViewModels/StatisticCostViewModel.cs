using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Data;
using SpaceSRM.Models;

namespace SpaceSRM.ViewModels
{
    public class StatisticCostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        readonly ICost costConnection = new CostRepository();
        readonly ISalary salaryConnection = new SalaryRepository();
        readonly IRecord recordConnection = new RecordRepository();

        List<Work> works = new List<Work>();
        List<Salary> salarys = new List<Salary>();
        List<Cost> costs = new List<Cost>();

        DateTime dateTo = DateTime.Today;
        DateTime dateFrom = DateTime.Today.AddMonths(-1);

        int allCost = 0;
        int generalCost = 0;
        int workCost = 0;
        int salaryCost = 0;

        public int AllCost
        {
            get => allCost;
            set{
                allCost = value;
                OnPropertyChanged();
            }
        }
        public int GeneralCost
        {
            get => generalCost;
            set
            {
                generalCost = value;
                OnPropertyChanged();
            }
        }
        public int WorkCost
        {
            get => workCost;
            set
            {
                workCost = value;
                OnPropertyChanged();
            }
        }
        public int SalaryCost
        {
            get => salaryCost;
            set
            {
                salaryCost = value;
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

        public ObservableCollection<LiveChartsCore.ISeries> SeriesCost { get; set; } = new ObservableCollection<ISeries>
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
            },
            new LineSeries<DateTimePoint>
            {
                TooltipLabelFormatter = (chartPoint) =>
                    $"{new DateTime((long) chartPoint.SecondaryValue):yyyy MM dd}: {chartPoint.PrimaryValue}",
                Values = new ObservableCollection<DateTimePoint>(),

                LineSmoothness = 0.6,
                Stroke = new SolidColorPaint(new SKColor(207, 209, 78)){ StrokeThickness = 10},
                Fill = null,
            }
        };


        public async void LoadingData()
        {
            works = await recordConnection.GetWorks();
            salarys = await salaryConnection.GetSalarys();
            costs = await costConnection.GetCosts();
        }
        public void VisualData()
        {
            if (dateFrom.Date > dateTo.Date)
            {
                DateTime dateTime = dateFrom;
                DateFrom = dateTo;
                DateTo = dateTime;
            }

            List<Work> worksVisualList = new List<Work>();
            List<Salary> salarysVisualList = new List<Salary>();
            List<Cost> costsVisualList = new List<Cost>();

            AllCost = 0;
            GeneralCost = 0;
            WorkCost = 0;
            SalaryCost = 0;

            List<DateTimePoint> workCosts = new List<DateTimePoint>();
            List<DateTimePoint> salaryCosts = new List<DateTimePoint>();
            List<DateTimePoint> generalCosts = new List<DateTimePoint>();

            for (DateTime i = dateFrom.Date; i <= dateTo.Date;i = i.AddDays(1))
            {
                int worksCostValue = 0;
                int salaryCostValue = 0;
                int generalCostValue = 0;

                worksVisualList = works.Where(u => u.Record.DateEnd.Date.Day == i.Day && u.Record.DateEnd.Date.Year == i.Year
                && u.Record.DateEnd.Date.Month == i.Month).ToList();
                salarysVisualList = salarys.Where(u => u.Date.Day == i.Day && u.Date.Year == i.Year && u.Date.Month == i.Month).ToList();
                costsVisualList = costs.Where(u => u.Date.Day == i.Day && u.Date.Year == i.Year && u.Date.Month == i.Month).ToList();
                foreach(var item in worksVisualList)
                {
                    WorkCost += item.PriceCost;
                    worksCostValue += item.PriceCost;
                }
                foreach(var item in salarysVisualList)
                {
                    SalaryCost += item.Value;
                    salaryCostValue += item.Value;
                }
                foreach(var item in costsVisualList)
                {
                    GeneralCost += item.Price;
                    generalCostValue += item.Price;
                }

                workCosts.Add(new DateTimePoint(new DateTime(i.Year, i.Month, i.Day), worksCostValue));
                salaryCosts.Add(new DateTimePoint(new DateTime(i.Year, i.Month, i.Day), salaryCostValue));
                generalCosts.Add(new DateTimePoint(new DateTime(i.Year, i.Month, i.Day), generalCostValue));

                worksVisualList.Clear();
                salarysVisualList.Clear();
                costsVisualList.Clear();
            }

            foreach (DateTimePoint point in workCosts)
            {
                ((ObservableCollection<DateTimePoint>)SeriesCost[0].Values).Add(point);
            }
            foreach (DateTimePoint point in salaryCosts)
            {
                ((ObservableCollection<DateTimePoint>)SeriesCost[1].Values).Add(point);
            }
            foreach (DateTimePoint point in generalCosts)
            {
                ((ObservableCollection<DateTimePoint>)SeriesCost[2].Values).Add(point);
            }
            AllCost = GeneralCost + SalaryCost + WorkCost;
        }
        public void ClearVisual()
        {

            SeriesCost[0].Values = new ObservableCollection<DateTimePoint>();
            SeriesCost[1].Values = new ObservableCollection<DateTimePoint>();
            SeriesCost[2].Values = new ObservableCollection<DateTimePoint>();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
