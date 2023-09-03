using Microsoft.Identity.Client;
using SpaceSRM.Date.Interface;
using SpaceSRM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace SpaceSRM.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly IRecord recordConnection = new Date.Repository.RecordRepository();
        ObservableCollection<Record> recordsVisual = new ObservableCollection<Record>();
        List<Record> records = new List<Record>();


        public ObservableCollection<Record> RecordsVisual
        {
            get => recordsVisual;
            set
            {
                recordsVisual = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadingData()
        {
            try
            {
                records = await recordConnection.GetRecordsWithColor();
                if(records == null)
                {
                    records = new List<Record>();
                }
            }
            catch { }
        }
        public List<DateTime> GetActionDates()
        {
            HashSet<DateTime> result = new HashSet<DateTime>();
            foreach (var record in records)
            {
                if(record.Status == Status.Wait)
                {
                    result.Add(new DateTime(record.DateStart.Date.Year, record.DateStart.Date.Month, record.DateStart.Date.Day));
                }
            }
            return new List<DateTime>(result);
        } 
        public  void ViewRecords(DateTime date)
        {
            var recordsToVisual = records.Where(f => ((f.DateEnd.Date >= date.Date) || (f.Status == Status.Wait
                || f.Status == Status.Work))
                &&
                ((f.DateStart.Date <= date.Date))).ToList().OrderByDescending( u => u.DateStart);
            RecordsVisual = new ObservableCollection<Record>(recordsToVisual);
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
