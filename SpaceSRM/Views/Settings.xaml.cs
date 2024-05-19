using SpaceSRM.ViewModels;
using SpaceSRM.Views.Forms;
using SpaceSRM.Views.Forms.DesktopSetting;
using SpaceSRM.Views.Forms.Mobile;

namespace SpaceSRM.Views;

public partial class Settings : ContentPage
{
	public Settings()
	{
		//Grid grid = new Grid {
		//	RowDefinition = { 
			
		//	},
		//	ColumnDefinition = { 
			
		//	}
		
		//};
		InitializeComponent();
	}

    private async void OnEditClient(object sender, EventArgs e)
    {
#if ANDROID || IOS
        Views.Forms.Mobile.ShowClientPage page = new Views.Forms.Mobile.ShowClientPage();
#else
        Forms.DesktopSetting.EditClientPage page = new Forms.DesktopSetting.EditClientPage();
#endif
        await Navigation.PushAsync(page);
    }
    private async void OnEditService(object sender, EventArgs e)
    {

#if ANDROID || IOS
        Forms.Mobile.ShowServicePage page = new Forms.Mobile.ShowServicePage();
#else
        Forms.DesktopSetting.EditServicePage page = new Forms.DesktopSetting.EditServicePage();
#endif



        await Navigation.PushAsync(page);
		
	}
    private async void OnEditSetService(object sender, EventArgs e)
    {

#if ANDROID || IOS
        Views.Forms.Mobile.ShowSetServivePage page = new Views.Forms.Mobile.ShowSetServivePage();
#else
        Forms.DesktopSetting.EditSetServicePage page = new Forms.DesktopSetting.EditSetServicePage();
#endif



        await Navigation.PushAsync(page);

    }
    private async void OnEditEmployer(object sender, EventArgs e)
    {

#if ANDROID || IOS
        Forms.Mobile.ShowEmployerPage page = new Forms.Mobile.ShowEmployerPage();
#else
        Forms.DesktopSetting.EditEmployerPage page = new Forms.DesktopSetting.EditEmployerPage();
#endif



        await Navigation.PushAsync(page);

    }
    //    private async void OnAddService(object sender, EventArgs e)
    //	{
    //#if ANDROID || IOS
    //		Forms.Mobile.AddServiceForm page = new Forms.Mobile.AddServiceForm();
    //#else
    //        Forms.Desktop.AddServiceForm page = new Forms.Desktop.AddServiceForm();
    //#endif
    //        await Navigation.PushAsync(page);

    //    }
}