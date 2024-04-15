using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views;

public partial class Costs : ContentPage
{
    public CostViewModel _vm = new CostViewModel();
    public bool _showDataClicked = false;
    public Costs()
	{
		InitializeComponent();
        BindingContext = _vm;
	}
    protected override async void OnAppearing()
    {

        await Task.Delay(900);
        await _vm.LoadingCosts();
        base.OnAppearing();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        try
        {
            int price;
            if(Name.Text == "" || Description.Text == "")
            {
                await DisplayAlert("SpaceSRM інформує",
                "ви невірно заповнили поля ім'я або опис",
               "Окей");
            }
            else if (!int.TryParse(Price.Text,out price))
            {
                await DisplayAlert("SpaceSRM інформує",
               "ви невірно ввели ціну",
               "Окей");
            }
            else
            {
                await _vm.AddCost(new Cost()
                {
                    Name = Name.Text,
                    Description = Description.Text,
                    Date = Date.Date,
                    Price = price,
                });
                await _vm.LoadingCosts();
            }
            

        }
        catch(Exception ex)
        {
            await DisplayAlert("SpaceSRM інформує",
                ex.Message,
                "Окей");
        }
       
    }

    private async void Edit_Clicked(object sender, EventArgs e)
    {
        await _vm.EditCost();
        await _vm.LoadingCosts();
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        await _vm.DeleteCost();
        await _vm.LoadingCosts();
    }

    private async void ShowButton_Clicked(object sender, EventArgs e)
    {
        if (_showDataClicked)
        {
            await HideDataAnimation();
            _showDataClicked = false;
        }
        else
        {
            await ShowDataAnimation();
            _showDataClicked = true;
        }
        
    }
    private async Task ShowDataAnimation()
    {
        await Task.WhenAll<bool>
        (
            DataForm.TranslateTo(0, 0, 500, Easing.CubicOut),
            ShowButton.TranslateTo(0, 440, 500, Easing.CubicOut),
            ShowButtonImage.RotateTo(90, 500, Easing.CubicOut),
            DataForm.FadeTo(0.97, 500, Easing.CubicOut)
        ) ;
        ShowButton.BackgroundColor = Color.FromArgb("#FA6D6D");
    }
    private async Task HideDataAnimation()
    {
        await Task.WhenAll<bool>
        (
            DataForm.TranslateTo(0, -440, 300, Easing.CubicOut),
            ShowButton.TranslateTo(0, 0, 300, Easing.CubicOut),
            ShowButtonImage.RotateTo(-90, 300, Easing.CubicOut),
            DataForm.FadeTo(0.2, 300, Easing.CubicOut)
        );
        ShowButton.BackgroundColor = Color.FromArgb("#4ED16B");
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_showDataClicked)
        {
            await HideDataAnimation();
            _showDataClicked = false;
        }
        else
        {
            await ShowDataAnimation();
            _showDataClicked = true;
        }
    }
}