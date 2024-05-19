using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class AddWorkForm : ContentPage
{
    RecordsViewModel _vm;
   
    bool IsAddService = false;
    bool IsAddEmployer = false;
    public AddWorkForm(RecordsViewModel vm)
	{
        InitializeComponent();
        BindingContext = _vm = vm;
	}
    protected override async void OnAppearing()
    {
        await Task.Delay(600);
        if (IsAddService)
        {
            await _vm.LoadingDataServices();
        }
        if(IsAddEmployer){
            await _vm.LoadingDataEmployers();
        }
        await Task.Run(() => {
            _vm.VisualDataEmployers();
            _vm.VisualDataServices();
        });
        
        base.OnAppearing();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        
        _vm.ClearVisualEmployers();
        _vm.ClearVisualServices();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnAddService(object sender, EventArgs e)
    {
        IsAddService = true;
        Forms.DesktopSetting.AddServiceForm page = new Forms.DesktopSetting.AddServiceForm();
        await Navigation.PushAsync(page);
    }
    

    private void SelectService_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Service current)
        {
            Price.Text = current.Price.ToString();
        }
    }

    private async void OnAddEmployer(object sender, EventArgs e)
    {
        IsAddEmployer = true;
        Forms.DesktopSetting.AddEmployerForm page = new Forms.DesktopSetting.AddEmployerForm();
        await Navigation.PushAsync(page);
    }
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        Work newWork = new Work();

        try
        {
            if (_vm.SelectService == null || _vm.SelectEmployers == null || _vm.SelectEmployers.Count == 0 || _vm.SelectService.Name == "")
            {
                _vm.SelectService = new Service();
                _vm.SelectEmployers = new List<Employer>();
                await Navigation.PopAsync();
                return;
            }         
            else
            {
                int price;
                int priceCost;
                if(!(int.TryParse(Price.Text,out price) && int.TryParse(PriceCost.Text, out priceCost)))
                {
                    await Navigation.PopAsync();
                    return;
                }
                else
                {
                    newWork.Price = price;
                    newWork.Service = _vm.SelectService;
                    newWork.Employers = _vm.SelectEmployers.ToList();
                    newWork.TruePrice = price;
                    newWork.DescriptionCost = DescriptionCost.Text;
                    newWork.PriceCost = priceCost;
                    //_vm.AddRecord.Works.Add(newWork);
                    _vm.WorksData.Add(newWork);  
                    _vm.SelectService = new Service();
                    _vm.SelectEmployers = new List<Employer>();
                    await Navigation.PopAsync();
                }
                
            }
            
        }
        catch
        {
            await Navigation.PopAsync();
        }
    }

    private void SelectionEmployers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            List<Employer> empl = e.CurrentSelection.Cast<Employer>().ToList(); ;
            if (empl != null) _vm.SelectEmployers = empl;
        }
        catch { }
    }
}