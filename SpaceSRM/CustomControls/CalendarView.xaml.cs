using SpaceSRM.Date.Models;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace SpaceSRM.CustomControls;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CalendarView : StackLayout
{
	#region BindableProperty
	public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
		nameof(SelectedDate),
		typeof(DateTime),
		declaringType:typeof(CalendarView),
		defaultBindingMode:BindingMode.TwoWay,
		defaultValue:DateTime.Now,
		propertyChanged:SelectedDatePropertyChanged
		);
	
    private static void SelectedDatePropertyChanged(BindableObject bindable,object oldValue,object newValue)
	{
		var controls = (CalendarView)bindable;
		if(newValue != null)
		{
			var newDate = (DateTime)newValue;
			if(controls._tempDate.Month == newDate.Month && controls._tempDate.Year == newDate.Year)
			{
				var currentDate = controls.Dates.Where(f => f.Date == newDate.Date).FirstOrDefault();
				if (currentDate != null)
				{
					controls.Dates.ToList().ForEach(f => f.IsCurrentDate = false);
					currentDate.IsCurrentDate = true;
				}
			}
			else
			{
                controls.BindDates(newDate);
            }
		}
	}
	private List<DateTime> actionDates = new List<DateTime>();
	public List<DateTime> ActionDates
	{
		get => actionDates;
		set {
			actionDates = value;
			BindDates(SelectedDate);	
		}
	}
    public DateTime SelectedDate
	{
		get => (DateTime)GetValue(SelectedDateProperty);
		set => SetValue(SelectedDateProperty, value);
	}
    public static readonly BindableProperty SelectedDateCommandProperty = BindableProperty.Create(
        nameof(SelectedDateCommand),
        typeof(ICommand),
        declaringType: typeof(CalendarView)
        );
	public ICommand SelectedDateCommand
	{
		get => (ICommand)GetValue(SelectedDateCommandProperty);
		set => SetValue(SelectedDateCommandProperty,value);
	}
	public event EventHandler<DateTime> OnDateSelected;
    private DateTime _tempDate;
	public DateTime TempDate
	{
		get => _tempDate;
		set
		{
			_tempDate = value;
			OnPropertyChanged();
		}
	}
	int spanCount = 7;

    public int SpanCount {
		get => spanCount;
		set => spanCount = value;
	}
	
    #endregion
    bool IsCalendar = true;
    public ObservableCollection<CalendarModel> Dates { get; set; } = new ObservableCollection<CalendarModel>();
    public CalendarView()
    {
        InitializeComponent();
        //BindDates(DateTime.Now);
    }
	

    private void BindDates(DateTime date)
	{
		Dates.Clear();
		int daysCount = DateTime.DaysInMonth(date.Year, date.Month);
		for(int days = 1;days <= daysCount; days++)
		{
			Dates.Add(new CalendarModel
			{
				Date = new DateTime(date.Year, date.Month, days)
				
			});
		}
		if (IsCalendar)
		{
            Dates.ToList().ForEach(f => f.IsCalendar = true);
        }
		Dates.Where(u => ActionDates.Contains(u.Date)).ToList().ForEach(m => m.HaveActions = true);
        var selectedDate = Dates.Where(f => f.Date == SelectedDate.Date).FirstOrDefault();
		if(selectedDate != null)
		{
            collectionView.ScrollTo(selectedDate, position: ScrollToPosition.Center);
            selectedDate.IsCurrentDate = true;
            TempDate = selectedDate.Date;         
        }
		
	}
	private async Task TransformToCalendar()
	{
        await collectionView.FadeTo(0, 300, Easing.CubicIn);
        await Task.Delay(100);
        collectionView.ItemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical) { Span = 7 };
        Dates.ToList().ForEach(f => f.IsCalendar = true);
        await Task.Delay(100);
        await collectionView.FadeTo(1, 300, Easing.CubicIn);
    }
    private async Task TransformToLine()
    {
        await collectionView.FadeTo(0, 300, Easing.CubicIn);
        await Task.Delay(50);
        collectionView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal) { ItemSpacing = 10};
		collectionView.ItemsSource = null;
		collectionView.ItemsSource = Dates;
		
		Dates.ToList().ForEach(f => f.IsCalendar = false);
        await Task.Delay(50);
        await collectionView.FadeTo(1, 300, Easing.CubicIn);
        var selectedDate = Dates.Where(f => f.Date == SelectedDate.Date).FirstOrDefault();
        await Task.Delay(50);
        if (selectedDate != null)
        {
            collectionView.ScrollTo(selectedDate, position: ScrollToPosition.Center);

        }
    }
    #region Commands
    public ICommand CurrentDateCommand => new Command<CalendarModel>(async (currentDate) => {
        TempDate = currentDate.Date;
        SelectedDate = currentDate.Date;
		OnDateSelected?.Invoke(null, currentDate.Date);
		SelectedDateCommand?.Execute(currentDate.Date);
		if (IsCalendar)
		{
			await TransformToLine();
			IsCalendar = false;
        }
		
		
    });
	public ICommand NextMonthCommand => new Command(() =>
	{
        TempDate = TempDate.AddMonths(1);
		BindDates(_tempDate);
	});
    public ICommand PreviousMonthCommand => new Command(() =>
    {
        TempDate = TempDate.AddMonths(-1);
        BindDates(TempDate);
    });
    public ICommand ShowHideCalendar => new Command(async () =>
    {
        if (IsCalendar)
        {
            await TransformToLine();
            IsCalendar = false;
        }
		else
		{
			await TransformToCalendar();
            IsCalendar = true;
        }
    });
    #endregion
}