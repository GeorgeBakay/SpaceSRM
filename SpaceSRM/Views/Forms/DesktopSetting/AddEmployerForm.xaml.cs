using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;

namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class AddEmployerForm : ContentPage
{
    readonly IEmployer employerConnection = new EmployerRepository();
    public AddEmployerForm()
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
            await DisplayAlert("SpaceSRM інформує", "Ви не ввели одне з полів, для нас це важдиво", "Окей");
            return;
        }

        else
        {
            string response = await employerConnection.AddEmployer(name, surName, phone);
            if (response == "Seccses")
            {
                Result.Text = "Новий працівник успішно доданий";
                Result.TextColor = Color.FromHex("#4ED16B");
                SemanticScreenReader.Announce(Result.Text);

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