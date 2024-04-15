using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class ShowServicePage : ContentPage
{
    EditServiceViewModel _vm = new EditServiceViewModel();
    private bool IsFirst = true;
    public ShowServicePage()
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

    private async void OnAddService(object sender, EventArgs e)
    {
        Forms.DesktopSetting.AddServiceForm page = new Forms.DesktopSetting.AddServiceForm();
        IsFirst = true;
        await Navigation.PushAsync(page);
    }


    private async void DataService_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.FirstOrDefault() is Service current)
        {
            _vm.ThisId = current.Id;
            _vm.ThisName = current.Name;
            _vm.ThisPrice = current.Price.ToString();
            _vm.ThisProcent = current.Procent.ToString();
            _vm.ThisType = current.Type;
            IsFirst = true;
            Views.Forms.Mobile.EditServicaForm page = new Views.Forms.Mobile.EditServicaForm(_vm);
            await Navigation.PushAsync(page);
        }

    }
}