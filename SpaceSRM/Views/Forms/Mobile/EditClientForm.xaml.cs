using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class EditClientForm : ContentPage
{
    public EditClientViewModel _vm = new EditClientViewModel();
    public EditClientForm(EditClientViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
    }
}