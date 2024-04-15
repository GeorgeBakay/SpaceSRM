using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class EditWorkForm : ContentPage
{
    RecordsViewModel _vm;
    public bool IsFirst = true;
    Work work;
    bool IsAddService = false;
    bool IsAddEmployer = false;
    public EditWorkForm(RecordsViewModel vm ,Work _current)
	{
        InitializeComponent();
        BindingContext = _vm = vm;
        work = _current;
    }
    protected override async void OnAppearing()
    {
        if (IsFirst)
        {

            await Task.Delay(700);
            if (IsAddService)
            {
                await _vm.LoadingDataServices();
            }
            if (IsAddEmployer)
            {
                await _vm.LoadingDataEmployers();
            }
            
                _vm.VisualDataEmployers();
                _vm.VisualDataServices();

             _vm.SelectWork = work;

             foreach (var item in SelectService.ItemsSource)
                  {
                                // Перевірка, чи елемент належить до колекції work.Employers
                  if (work.Service == item)
                  {
                                    // Додавання елементу до списку SelectedItem
                     SelectService.SelectedItem = item;
                  }
             }
            List<object> selectEmployers = new List<object>();
            foreach (var item in SelectionEmployers.ItemsSource)
            {
                // Перевірка, чи елемент належить до колекції work.Employers
                if (work.Employers.Contains(item))
                {
                    // Додавання елементу до списку SelectedItems
                    selectEmployers.Add(item);

                }
            }
            foreach (var item in selectEmployers)
            {
                SelectionEmployers.SelectedItems.Add(item);
            }
        }
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
    private void SelectionEmployers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            List<Employer> empl = e.CurrentSelection.Cast<Employer>().ToList(); ;
            if (empl != null) _vm.SelectWork.Employers = empl;
        }
        catch
        {
        }
    }
    private async void OnAddService(object sender, EventArgs e)
    {
        IsAddService = true;
        Forms.DesktopSetting.AddServiceForm page = new Forms.DesktopSetting.AddServiceForm();
        await Navigation.PushAsync(page);
    }
    private async void OnAddEmployer(object sender, EventArgs e)
    {
        IsAddEmployer = true;
        Forms.DesktopSetting.AddEmployerForm page = new Forms.DesktopSetting.AddEmployerForm();
        await Navigation.PushAsync(page);
    }
    private async void EditClicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();
    }
    private async void Delete_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("SpaceSRM інформує",
            "Ви точно хочете видалити цю роботу",
            "Ні", "Так");
        if (!answer)
        {
            _vm.AddRecord.Sum -= _vm.SelectWork.Price;
            _vm.Sum -= _vm.SelectWork.Price;
            //_vm.AddRecord.Works.Remove(_vm.SelectWork);
            _vm.WorksData.Remove(_vm.SelectWork);
            await Navigation.PopAsync();
        }
    }
}