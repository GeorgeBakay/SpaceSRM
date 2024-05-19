using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;

namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class AddClientForm : ContentPage
{
    readonly IClient client = new ClientRepository();
    public AddClientForm()
	{
		InitializeComponent();
	}
    [Obsolete]
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        string name = Name.Text;
        string surName = SurName.Text;
        string phone = Phone.Text;
       
     

        if (name == null || surName == null || phone == null || name == "" || phone == "" || surName == "")
        {
            await DisplayAlert("SpaceSRM інформує", "Ви не ввели одне з полів, для нас це важливо", "Окей");
            return;
        }
        
        else
        {
            string response = await client.AddClient(name, surName,phone);
            if (response == "Seccses")
            {
                Result.Text = "Новий клієнт успішно доданий";
                Result.TextColor = Color.FromHex("#4ED16B");
                SemanticScreenReader.Announce(Result.Text);
                await Task.Delay(200);
                await Navigation.PopAsync();

            }
            else
            {
                Result.Text = response;
                Result.TextColor = Color.FromHex("#FA6D6D");
                SemanticScreenReader.Announce(Result.Text);

            }
        }

    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}