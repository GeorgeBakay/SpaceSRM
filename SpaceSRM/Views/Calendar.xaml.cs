using Microsoft.Maui.Controls;
using SpaceSRM.ViewModels;
using Syncfusion.Maui.Calendar;

namespace SpaceSRM.Views;

public partial class Calendar : ContentPage
{
	CalendarViewModel _vm = new CalendarViewModel();
	public Calendar()
	{
		InitializeComponent();
		BindingContext = _vm;
	}
}