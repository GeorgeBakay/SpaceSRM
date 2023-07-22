using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Statistic;

public partial class StatisticEmployer : ContentPage
{
    StatisticEmployerViewModel _vm;
    public bool IsFirst = true;
    public bool _showDataClicked = false;
    public StatisticEmployer(StatisticEmployerViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;


    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (IsFirst)
        {
            await Task.Delay(500);

            _vm.ClearVisual();
            _vm.VisualWorksStats();


        }
        IsFirst = false;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        IsFirst = true;
        _vm.ClearVisual();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void DateFrom_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!IsFirst)
        {

            _vm.ClearVisual();
            _vm.VisualWorksStats();

        }
    }
    private void DateTo_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (!IsFirst)
        {
            _vm.ClearVisual();
            _vm.VisualWorksStats();
        }
    }

    private async void ShowDataClick(object sender, EventArgs e)
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

    private async void AddSalaryClicked(object sender, EventArgs e)
    {
        int value = 0;
        if(int.TryParse(Value.Text,out value))
        {
            _vm.Salary.Value = value;
            await _vm.AddSalary();
            await _vm.UpdateSalary();
            await HideDataAnimation();
        }
        
    }

    private async void EditSalaryClicked(object sender, EventArgs e)
    {
        int value = 0;
        if (int.TryParse(Value.Text, out value))
        {
            _vm.Salary.Employer = new Models.Employer();
            _vm.Salary.Value = value;
            await _vm.EditSalary();
   
            await _vm.UpdateSalary();
            await HideDataAnimation();
        }
        
    }

    private async void DeleteSalaryClicked(object sender, EventArgs e)
    {

        await _vm.DeleteSalary();
         await _vm.UpdateSalary();
        await HideDataAnimation();

    }
    private async Task ShowDataAnimation()
    {
        await Task.WhenAll<bool>
        (
            DataSalary.TranslateTo(0, 0, 500, Easing.CubicOut),
           
            ShowButtonImage.RotateTo(180, 500, Easing.CubicOut),
            DataSalatyTable.FadeTo(0.3, 500, Easing.CubicOut)
        );
        ShowDataButton.BackgroundColor = Color.FromArgb("#FA6D6D");
    }
    private async Task HideDataAnimation()
    {
        await Task.WhenAll<bool>
        (
          DataSalary.TranslateTo(1000,0, 500, Easing.CubicOut),

          ShowButtonImage.RotateTo(0, 500, Easing.CubicOut),
          DataSalatyTable.FadeTo(1, 500, Easing.CubicOut)
        );
        ShowDataButton.BackgroundColor = Color.FromArgb("#4ED16B");
       
    }

    private async void CollectionSalarySelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        await ShowDataAnimation();
    }
}