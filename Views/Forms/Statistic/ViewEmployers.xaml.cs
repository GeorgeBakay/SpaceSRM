using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Statistic;

public partial class ViewEmployers : ContentPage
{
    StatisticEmployerViewModel _vm = new StatisticEmployerViewModel();

    public bool IsFirst = true;
    
    public ViewEmployers()
	{
		InitializeComponent();
        BindingContext = _vm;
	}
    protected override async void OnAppearing()
    {

        if (IsFirst)
        {
           
             await Task.Delay(300);
             await _vm.LoadingData();
            
        }
        IsFirst = false;
        base.OnAppearing();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void DataEmployer_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!IsFirst)
        {
            _vm.WorksVisual = new System.Collections.ObjectModel.ObservableCollection<VisualWorksOfEmployer>();
            await Navigation.PushAsync(new Forms.Statistic.StatisticEmployer(_vm));
            //DataEmployers.SelectedItem = null;
        }
    }
}