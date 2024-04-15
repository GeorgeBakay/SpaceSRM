using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class ShowSetServivePage : ContentPage
{
    EditSetServiceViewModel _vm = new EditSetServiceViewModel();
    private bool IsFirst = true;
    public ShowSetServivePage()
	{
		InitializeComponent();
        BindingContext = _vm;
    }
    protected override async void OnAppearing()
    {
        if (IsFirst)
        {
            await Task.Run(
                async () => {
                    await Task.Delay(500);
                    await _vm.LoadingData();
                });
            IsFirst = false;
        }

        base.OnAppearing();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnAddSetService(object sender, EventArgs e)
    {
        IsFirst = true;
        Forms.DesktopSetting.AddSetServiceForm page = new Forms.DesktopSetting.AddSetServiceForm(_vm);
        await Navigation.PushAsync(page);
    }

    private async void DataService_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is SetService current)
        {
            _vm.ThisId = current.Id;
            _vm.ThisName = current.Name;
            _vm.ThisDiscount = current.Discount;
            _vm.ThisServices = current.Services.ToList();
            IsFirst = true;
            Views.Forms.Mobile.EditSetServiceForm page = new Views.Forms.Mobile.EditSetServiceForm(_vm);
            await Navigation.PushAsync(page);
        }
    }
}