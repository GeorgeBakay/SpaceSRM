using SpaceSRM.ViewModels;
using System.Collections.ObjectModel;

namespace SpaceSRM.Views.Forms.Statistic;

public partial class StatisticWorks : ContentPage
{
    public StatisticViewModel _vm = new StatisticViewModel();


    public bool IsFirst = true;

    public StatisticWorks(StatisticViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }
    protected override async void OnAppearing()
    {
       
        
            await Task.Delay(500);
            _vm.VisualWorksStats();
            await Task.Delay(500);
            _vm.VisualWorksList();
            IsFirst = false;
        
        

        base.OnAppearing();
    }
    protected override  void OnDisappearing()
    {
        
        
        _vm.WorksVisual = new ObservableCollection<Models.Work>();
        
        base.OnDisappearing();
    }

    private void DateFrom_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!IsFirst)
        {
            
                _vm.WorksVisual = new ObservableCollection<Models.Work>();


                _vm.VisualWorksStats();
                _vm.VisualWorksList();
          
        }
        
    }

    private void DateTo_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!IsFirst)
        {
            
                _vm.WorksVisual = new ObservableCollection<Models.Work>();
                
                _vm.VisualWorksStats();
                _vm.VisualWorksList();
            
        }
    }
}