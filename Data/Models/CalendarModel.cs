using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSRM.Date.Models
{
    public class CalendarModel : PropertyChangedModel
    {
        public DateTime Date { get; set; }
        private bool _isCurrentDate;
        private bool _isCalendar = false;
        public bool _haveActions = false;
        public bool HaveActions
        {
            get => _haveActions;
            set => SetProperty(ref _haveActions, value);
        }
        public bool IsCurrentDate
        {
            get => _isCurrentDate;
            set => SetProperty(ref _isCurrentDate, value);
        }
        public bool IsCalendar
        {
            get => _isCalendar;
            set => SetProperty(ref _isCalendar, value);
        }
    }
}
