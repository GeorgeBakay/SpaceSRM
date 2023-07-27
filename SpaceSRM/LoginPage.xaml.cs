
using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;

namespace SpaceSRM.Views;

public partial class LoginPage : ContentPage
{
    private ILogin _login = new LoginRepository();
    public LoginPage()
	{
		InitializeComponent();
        
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(500);
        await round1.FadeTo(1, 300,Easing.CubicOut);
        await round2.FadeTo(1, 300, Easing.CubicOut);
        await round3.FadeTo(1, 300, Easing.CubicOut);
        await round4.FadeTo(1, 300, Easing.CubicOut);
        await round5.FadeTo(1, 300, Easing.CubicOut);

        
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        if(User.Text != null && Password.Text != null)
        {
            await LoginForm.FadeTo(0, 300, Easing.CubicOut);
            string userName = User.Text;
            string password = Password.Text;
            bool isValid = await _login.Login(userName, password);
            if (isValid)
            {
                
                await round1.ScaleTo(40, 1000,Easing.CubicIn);




                await SecureStorage.Default.SetAsync("userName", userName);
                await SecureStorage.Default.SetAsync("password", password);

                //await Navigation.PushAsync(new AppShellMobile());
                Application.Current.MainPage = new AppShellMobile();
            }
            else
            {
                await LoginForm.FadeTo(1, 300, Easing.CubicOut);
                await DisplayAlert("Помилка логінізації", "пароль або логін введені невірно, також пеервірте підключення до інтернету", "Знову");
            }
        }
        else
        {
            await DisplayAlert("Помилка введення", "Ви ввели порожні поля", "Знову");
        }
        
    }
}