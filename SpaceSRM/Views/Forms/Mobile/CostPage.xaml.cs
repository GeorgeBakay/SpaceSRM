using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class CostPage : ContentPage
{
    public CostViewModel _vm = new CostViewModel();

    public CostPage()
    {
        InitializeComponent();
        BindingContext = _vm;
    }
    protected override async void OnAppearing()
    {
        await Task.Delay(900);
        await _vm.LoadingCosts();
        base.OnAppearing();
    }
}