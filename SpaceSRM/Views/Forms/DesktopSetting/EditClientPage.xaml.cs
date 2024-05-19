using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class EditClientPage : ContentPage
{
	private readonly EditClientViewModel _vm = new EditClientViewModel();
    private bool IsFirst = true;
	public EditClientPage()
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
                    await Task.Delay(200);
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
}