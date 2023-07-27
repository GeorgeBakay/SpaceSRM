using SpaceSRM.Date.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SpaceSRM.CustomControls;

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
    #endregion
    public ObservableCollection<CalendarModel> Dates { get; set; } = new ObservableCollection<CalendarModel>();
    public CalendarView()
    {
        InitializeComponent();
        BindDates(DateTime.Now);
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
		
		var selectedDate = Dates.Where(f => f.Date == SelectedDate.Date).FirstOrDefault();
		if(selectedDate != null)
		{
            collectionView.ScrollTo(selectedDate, position: ScrollToPosition.Center);
            selectedDate.IsCurrentDate = true;
            TempDate = selectedDate.Date;         
        }
		
	}
	#region Commands
	public ICommand CurrentDateCommand => new Command<CalendarModel>((currentDate) => {
        TempDate = currentDate.Date;
        SelectedDate = currentDate.Date;
		OnDateSelected?.Invoke(null, currentDate.Date);
		SelectedDateCommand?.Execute(currentDate.Date);
        collectionView.ScrollTo(currentDate, position: ScrollToPosition.Center);

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
    #endregion
}