using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class EditServicePage : ContentPage
{

    EditServiceViewModel _vm = new EditServiceViewModel();
    private bool IsFirst = true;
    public EditServicePage()
    {      
        InitializeComponent();
        BindingContext = _vm;
    }
    
    protected override async void OnAppearing()
    {
        if (IsFirst)
        {
            await Task.Run(() => _vm.LoadingData());
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
        await Navigation.PushAsync(page);
    }

}