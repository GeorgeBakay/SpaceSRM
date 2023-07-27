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
        
        public async void LoadingData()
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
        public  void ViewRecords(DateTime date)
        {
            var recordsToVisual = records.Where(f => f.DateEnd.Date.Month >= date.Date.Month
                && f.DateEnd.Date.Year >= date.Date.Year && f.DateEnd.Date.Day >= date.Date.Day
                && f.DateStart.Date.Year <= date.Date.Year && f.DateStart.Date.Month <= date.Date.Month
                && f.DateStart.Date.Day <= date.Date.Day).ToList();
            RecordsVisual = new ObservableCollection<Record>(recordsToVisual);
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
