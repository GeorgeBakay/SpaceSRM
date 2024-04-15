using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class EditSetServicePage : ContentPage
{
	EditSetServiceViewModel _vm = new EditSetServiceViewModel();
    private bool IsFirst = true;
    public EditSetServicePage()
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
    private async void OnAddSetService(object sender, EventArgs e)
    {
        IsFirst = true;
        Forms.DesktopSetting.AddSetServiceForm page = new Forms.DesktopSetting.AddSetServiceForm(_vm);
        await Navigation.PushAsync(page);
    }
}