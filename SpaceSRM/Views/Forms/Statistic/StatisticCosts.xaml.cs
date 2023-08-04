using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Statistic;

public partial class StatisticCosts : ContentPage
{
    private StatisticCostViewModel _vm = new StatisticCostViewModel();
    bool IsFirst = true;
    public StatisticCosts()
	{
		InitializeComponent();
        BindingContext = _vm;
       
	}
    protected override async void OnAppearing()
    {
        await Task.Delay(300);
        _vm.LoadingData();
        if (IsFirst)
        {
            await Task.Delay(500);

            _vm.ClearVisual();
            _vm.VisualData();


        }
        IsFirst = false;
        base.OnAppearing();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private void DateFrom_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!IsFirst)
        {

            _vm.ClearVisual();
            _vm.VisualData();

        }
    }
    private void DateTo_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!IsFirst)
        {
            _vm.ClearVisual();
            _vm.VisualData();
        }
    }

}