using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;

namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class AddServiceForm : ContentPage
{
	readonly IService service = new ServiceRepository();
	public AddServiceForm()
	{
		
		InitializeComponent();
	}


    [Obsolete]
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
		string name = Name.Text;
		string type = Type.Text;
		string price = Price.Text;
		string procent = Procent.Text;
		int PriceInt;
		int ProcentInt;

		if(name == null || type == null || name == "" || type == "")
		{
			await DisplayAlert("SpaceSRM �������", "�� �� ����� ����� ��� ��� �������, ��� ��� �� �������","����");
			return;
		}
		else if( !(int.TryParse(price, out PriceInt)) || !(int.TryParse(procent, out ProcentInt)))
		{
            await DisplayAlert("SpaceSRM �������", 
				"�� ����� ���� ��� ������� ����������� � ������������� ������, " +
				"� �� ���� �������� ��� �������� � ��, ������ �� � ������ ����� ����� , ��������� 3500 35",
				"����");
            return;
        }
		else if(ProcentInt > 100 || ProcentInt < 0)
		{
            await DisplayAlert("SpaceSRM �������",
                "�� ����� ������� ����������� � ������������� ������, ����� 100 ��� ����� 0 " +
                "� ����������� ��� �������� �� ����� ���� �������� ��� ��������� ���� �� ���������",
                "����");
            return;
        }
		else
		{
            string response = await service.AddService(name, type, PriceInt, ProcentInt);
            if (response == "Seccses")
            {
				Result.Text = "���� ������� ������ ������";
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