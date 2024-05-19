
using SpaceSRM.Views;
namespace SpaceSRM;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class App : Application
{
  
    public App()
	{
      
		InitializeComponent();
        MainPage = new NavigationPage(new LoginPage());

    }
  
}
