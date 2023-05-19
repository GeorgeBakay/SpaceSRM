using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class ShowEmployerPage : ContentPage
{
    private readonly EditEmployerViewModel _vm = new EditEmployerViewModel();
    private bool IsFirst = true;
    public ShowEmployerPage()
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
    private async void OnAddEmployer(object sender, EventArgs e)
    {
        IsFirst = true;
        Forms.DesktopSetting.AddEmployerForm page = new Forms.DesktopSetting.AddEmployerForm();
        await Navigation.PushAsync(page);
    }

    private async void DataService_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Employer current)
        {
            _vm.ThisId = current.Id;
            _vm.ThisName = current.Name;
            _vm.ThisPhone = current.Phone;
            _vm.ThisSurName = current.SurName;
            IsFirst = true;
            Views.Forms.Mobile.EditEmployerForm page = new Views.Forms.Mobile.EditEmployerForm(_vm);
            await Navigation.PushAsync(page);
        }

    }
}