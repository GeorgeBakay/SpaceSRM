using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;
using SpaceSRM.Models;
using SpaceSRM.ViewModels;


namespace SpaceSRM.Views.Forms.DesktopSetting;

public partial class AddSetServiceForm : ContentPage
{
    EditSetServiceViewModel vm;
    ISetService setService = new SetServiceRepository();
    bool itFirst = true;
	public AddSetServiceForm(EditSetServiceViewModel _vm)
	{
		InitializeComponent();
		BindingContext = vm = _vm;
	}
    protected override async void OnAppearing()
    {
        if (itFirst)
        {
            await Task.Run(() => vm.LoadingServicesData());
            itFirst = false;
        }
        
        base.OnAppearing();
    }
    [Obsolete]
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        string name = Name.Text;
        List<Service> service = CheckService.SelectedItems.Cast<Service>().ToList();
        string discount = Discount.Text;
       
        int DiscountInt;
        

        if (name == null || name == "" )
        {
            await DisplayAlert("SpaceSRM інформує", "Ви не ввели назву , для нас це важдиво", "Окей");
            return;
        }
        else if (!(int.TryParse(discount, out DiscountInt)))
        {
            await DisplayAlert("SpaceSRM інформує",
                "Ви ввели  процент  в неправильному форматі, " +
                "я не можу записати такі значення в БД, введіть їх в форматі цілих чисел , наприклад 3500 35",
                "Окей");
            return;
        }
        else if(service == null || service.Count == 0)
        {
            await DisplayAlert("SpaceSRM інформує",
                "Вине вибрали набір послуг" +
                "я не можу записати такі значення в БД",
                "Окей");
            return;
        }
        else
        {
            string response = await setService.AddSetService(name, service, DiscountInt);
            if (response == "Seccses")
            {
                Result.Text = "Новий набір послуг успішно доданий";
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