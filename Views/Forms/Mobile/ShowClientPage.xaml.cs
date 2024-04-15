using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class ShowClientPage : ContentPage
{
    private readonly EditClientViewModel _vm = new EditClientViewModel();
    private bool IsFirst = true;
    public ShowClientPage()
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
    private async void OnAddClient(object sender, EventArgs e)
    {
        IsFirst = true;
        Forms.DesktopSetting.AddClientForm page = new Forms.DesktopSetting.AddClientForm();
        await Navigation.PushAsync(page);
    }

    private async void DataService_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Client current)
        {
            _vm.ThisId = current.Id;
            _vm.ThisName = current.Name;
            _vm.ThisPhone = current.Phone;
            _vm.ThisSurName = current.SurName;
            IsFirst = true;
            Views.Forms.Mobile.EditClientForm page = new Views.Forms.Mobile.EditClientForm(_vm);
            await Navigation.PushAsync(page);
        }
    }
}