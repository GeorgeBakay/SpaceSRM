using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Statistic;

public partial class StatisticClient : ContentPage
{
    public StatisticClientViewModel _vm;
    public bool IsFirst = true;
    public int screenWidth;
    public StatisticClient(StatisticClientViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
        screenWidth = ((int)scrollView.Width/3) - 30; 
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (IsFirst)
        {
            await Task.Delay(500);
            _vm.ClearVisual();
            _vm.VisualLoading();
        }
        IsFirst = false;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        IsFirst = true;
        _vm.ClearVisual();
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
            _vm.VisualLoading();

        }
    }
    private void DateTo_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!IsFirst)
        {
            _vm.ClearVisual();
            _vm.VisualLoading();
        }
    }
}