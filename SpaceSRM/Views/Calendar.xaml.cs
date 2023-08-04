//using Microsoft.Maui.Controls;

using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views;

public partial class Calendar : ContentPage
{
	CalendarViewModel _vm = new CalendarViewModel();
    bool IsFirst = true;
	public Calendar()
	{
		InitializeComponent();
		BindingContext = _vm;
	}
    protected override async void OnAppearing()
	{
		await Task.Delay(300);
		_vm.LoadingData();
        await Task.Delay(100);
        cal.ActionDates = _vm.GetActionDates();
        
        if (IsFirst)
        {
            _vm.ViewRecords(DateTime.Now);
            IsFirst = false;
        }
        cal.SelectedDate = DateTime.Now;
        base.OnAppearing();
    }
    private async void cal_OnDateSelected(object sender, DateTime e)
    {
		await DataRecords.TranslateTo(0, 700, 500,Easing.CubicIn);
        await Task.Delay(200);
        _vm.ViewRecords(e);
		await Task.Delay(200);
        await DataRecords.TranslateTo(0, 0,300, Easing.CubicOut);
    }

    private async void DataRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Record current)
		{
            await Navigation.PushAsync(new Forms.Mobile.EditRecordForm(new RecordsViewModel() { SelectRecord = current }));
        }
    }

    private async void Phone_Clicked(object sender, EventArgs e)
    {

        string phoneNumber = ((Button)sender).Text;
        var uri = new Uri($"tel:{phoneNumber}");
        await Launcher.OpenAsync(uri);
    }
}