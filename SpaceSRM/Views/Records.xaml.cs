using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views;

public partial class Records : ContentPage
{
	private RecordsViewModel _vm = new RecordsViewModel();
    private bool IsFirst = true;
    private bool isInitialized = true;

    public Records()
	{
        InitializeComponent();
        BindingContext = _vm;
	}
    protected override async void OnAppearing()
    {
        if (IsFirst)
        {
            await Task.Run(
                async () => {
                    
                    await Task.Delay(500);
                    await _vm.LoadingDataRecords();
                });
            IsFirst = false;
        }

        base.OnAppearing();
    }
    //Open page to new Record 
    private async void OnAddRecord(object sender, EventArgs e)
    {
        _vm.Records = new System.Collections.ObjectModel.ObservableCollection<Models.Record>();
        _vm.AddRecord = new Record();
        IsFirst = true;
        await Navigation.PushAsync(new Forms.DesktopSetting.AddRecordForm());
        

    }
    //Open page to edit Record when we select some item
    private async void DataRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _vm.Records = new System.Collections.ObjectModel.ObservableCollection<Models.Record>();
        _vm.AddRecord = new Record();
        _vm.Works = new System.Collections.ObjectModel.ObservableCollection<Work>();
        _vm.PhotoAfter = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        _vm.PhotoBefore = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        _vm.PhotoBeforePrevious = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        _vm.PhotoAfterPrevious = new System.Collections.ObjectModel.ObservableCollection<Date.Models.CustomPhoto>();
        IsFirst = true;
        await Navigation.PushAsync(new Forms.Mobile.EditRecordForm(_vm));
        
    }
}