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

namespace SpaceSRM.ViewModels
{
    public class CostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Cost selectedCost = new Cost() { 
            Date = DateTime.Now,
        };

        ObservableCollection<Cost> costs = new ObservableCollection<Cost>();
        ICost _costConnection = new CostRepository();
        string status = "";
        bool _isBusy = true;
        public bool IsBusy
        {
            get => _isBusy;
            set 
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Cost> Costs
        {
            get => costs;
            set
            {
                costs = value;
                OnPropertyChanged();
            }
        }
        public Cost SelectedCost
        {
            get => selectedCost;
            set
            {
                selectedCost = value;
                OnPropertyChanged();
            }
        }
        public async Task EditCost()
        {
            string answer = await _costConnection.EditCost(SelectedCost);
            Status = answer;
        }
        public async Task AddCost(Cost cost)
        {
            string answer = await _costConnection.AddCost(cost);
            Status = answer;
        }
        public async Task DeleteCost()
        {
            if (SelectedCost.Id != -1)
            {
                string answer = await _costConnection.DeleteCost(SelectedCost.Id);
                Status = answer;
            }
            
        }
        public async Task LoadingCosts()
        {
            SelectedCost = new Cost()
            {
                Date = DateTime.Now,
            };
            Costs = new ObservableCollection<Cost>();
            IsBusy = true;
            List<Cost> costsLoad = await _costConnection.GetCosts();
            if(costsLoad.Count != 0)
            {
                
                Costs = new ObservableCollection<Cost>(costsLoad);
                
            }
            IsBusy = false;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
