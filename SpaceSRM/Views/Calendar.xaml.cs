using Microsoft.Maui.Controls;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views;

public partial class Calendar : ContentPage
{
	CalendarViewModel _vm = new CalendarViewModel();
	public Calendar()
	{
		InitializeComponent();
		cal.SelectedDate = DateTime.Now;
		BindingContext = _vm;
	}
    protected override async void OnAppearing()
	{
		await Task.Delay(500);
		_vm.LoadingData();
	}
    private async void cal_OnDateSelected(object sender, DateTime e)
    {
		await DataRecords.TranslateTo(0, 700, 500,Easing.CubicIn);
        await Task.Delay(200);
        _vm.ViewRecords(e);
		await Task.Delay(200);
        await DataRecords.TranslateTo(0, 0,300, Easing.CubicOut);
    }
}