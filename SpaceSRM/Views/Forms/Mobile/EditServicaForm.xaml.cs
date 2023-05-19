using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class EditServicaForm : ContentPage
{
    EditServiceViewModel _vm = new EditServiceViewModel();
    public EditServicaForm(EditServiceViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}