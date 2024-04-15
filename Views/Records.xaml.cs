using SpaceSRM.Models;
using SpaceSRM.ViewModels;
using System.Collections.ObjectModel;

namespace SpaceSRM.Views;

public partial class Records : ContentPage
{
	private RecordsViewModel _vm = new RecordsViewModel();
    private bool IsFirst = true;

    public Records()
	{
        InitializeComponent();
        BindingContext = _vm;
	}
    protected override async void OnAppearing()
    {
        if (IsFirst)
        {
            await Task.Delay(200);
            await Task.Run(async () => {
                await _vm.LoadingDataRecords();
            });
            
            IsFirst = false;
        }

        base.OnAppearing();
    }
    //Open page to new Record 
    private void OnAddRecord(object sender, EventArgs e)
    {

       
        IsFirst = true;
        OpenAddRecordPage();

    }
    private async void OpenAddRecordPage()
    {
        await Navigation.PushAsync(new Forms.DesktopSetting.AddRecordForm());
        _vm.Records = new System.Collections.ObjectModel.ObservableCollection<Models.Record>();
    }
    //Open page to edit Record when we select some item
    private async void DataRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        _vm.AddRecord = new Record();
        _vm.Clients = new System.Collections.ObjectModel.ObservableCollection<Client>();
        _vm.WorksData = new List<Work>();
        _vm.PhotoAfter = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        _vm.PhotoBefore = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        _vm.PhotoBeforePrevious = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        _vm.PhotoAfterPrevious = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        IsFirst = true;
        await Navigation.PushAsync(new Forms.Mobile.EditRecordForm(_vm));
        _vm.Records = new System.Collections.ObjectModel.ObservableCollection<Models.Record>();


    }

    private async void RefreshView_Refreshing(object sender, EventArgs e)
    {
        var Sender = sender as RefreshView;
        _vm.Records = new System.Collections.ObjectModel.ObservableCollection<Models.Record>();
        await _vm.LoadingDataRecords();
        Sender.IsRefreshing = false;
    }
}