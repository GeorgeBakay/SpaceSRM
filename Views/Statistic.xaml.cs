using SpaceSRM.ViewModels;
using System.Collections.ObjectModel;

namespace SpaceSRM.Views;

public partial class Statistic : ContentPage
{
	public StatisticViewModel _vm = new StatisticViewModel();
    public bool IsFirts = true;
    public Statistic()
	{
		InitializeComponent();
		BindingContext = _vm;
	}

    protected override async void OnAppearing()
    {
        
        if (IsFirts)
        {
            await Task.Delay(300);
            await Task.Run(async () =>{        
                await _vm.LoadingData();
            });
           
            IsFirts = false;
        }
        await Task.Run(() =>
        {
            _vm.AngleAxes[0].Labels = new ObservableCollection<string>();
            _vm.SeriesWorks[0].Values = new ObservableCollection<int>();
            _vm.WorksVisual = new ObservableCollection<Models.Work>();
        });


        base.OnAppearing();
    }

    private async void Record_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Forms.Statistic.ViewRecords());
    }

    private async void Works_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Forms.Statistic.StatisticWorks(_vm));
    }

    private async void Employers_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Forms.Statistic.ViewEmployers());
    }

    private async void Client_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Forms.Statistic.ViewClients());
    }
    private async void Cost_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Forms.Statistic.StatisticCosts());
    }
}