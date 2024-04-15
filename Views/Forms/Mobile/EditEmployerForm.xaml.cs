using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class EditEmployerForm : ContentPage
{
    EditEmployerViewModel _vm = new EditEmployerViewModel();
    public EditEmployerForm(EditEmployerViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}