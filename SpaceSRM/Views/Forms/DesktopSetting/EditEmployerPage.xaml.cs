using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class EditEmployerPage : ContentPage
{
    private readonly EditEmployerViewModel _vm = new EditEmployerViewModel();
    private bool IsFirst = true;
    public EditEmployerPage()
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
            await Task.Run(() => _vm.LoadingData());
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
}