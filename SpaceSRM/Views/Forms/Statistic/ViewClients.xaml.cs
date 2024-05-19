using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Statistic;

public partial class ViewClients : ContentPage
{
    public StatisticClientViewModel _vm = new StatisticClientViewModel();
    public bool IsFirst = true;
    public bool IsFirstLoding = true;
    public ViewClients()
	{
		InitializeComponent();
        BindingContext = _vm;
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(300);
        if (IsFirstLoding)
        {  
            await _vm.LoadingData();
        }
        _vm.VisualClients();
        IsFirstLoding = false;

    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _vm.ClearClients();
    }
    private async void DataClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       
            await Navigation.PushAsync(new Forms.Statistic.StatisticClient(_vm));
            
      
    }
}