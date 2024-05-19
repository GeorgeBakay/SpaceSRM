using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class EditSetServiceForm : ContentPage
{
    EditSetServiceViewModel _vm = new EditSetServiceViewModel();
    public EditSetServiceForm(EditSetServiceViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}