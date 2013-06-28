using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Wpf.Models
{
    public class SetterModel : SetterBase, IDisplayText
    {
        public const string TimeProperty = "Time";
        public const string StatusProperty = "Status";
        public const string CountProperty = "Count";
        public const string DisplayTextProperty = "DisplayText";

        private readonly string _displayText;
        public string DisplayText
        {
            get { return _displayText; }
        }

        private DateTime _time;
        public DateTime Time
        {
            get { return _time; }
            set { Set(TimeProperty, ref _time, value); }
        }

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { Set(StatusProperty, ref _status, value); }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
        }

        public SetterModel(int id)
        {
            PropertyChanged += OnPropertyChanged;
            _displayText = "Setter Model : " + id;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == StatusProperty)
            {
                _count += 1;
                RaisePropertyChanged(CountProperty);
            }
        }

        public static IDisplayText Create(int i)
        {
            return new SetterModel(i);
        }
    }
}
