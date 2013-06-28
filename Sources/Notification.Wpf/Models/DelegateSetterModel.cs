using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Wpf.Models
{
    public class DelegateSetterModel : DelegateSetterBase, IDisplayText
    {
        public const string TimeProperty = "Time";
        public const string StatusProperty = "Status";
        public const string CountProperty = "Count";
        public const string DisplayTextProperty = "DisplayText";

        private class Inner : IDisplayText
        {
            public string DisplayText { get; set; }

            public DateTime Time { get; set; }

            public bool Status { get; set; }

            public int Count { get; set; }
        }

        private readonly Inner _inner = new Inner();

        public string DisplayText
        {
            get { return _inner.DisplayText; }
        }

        public DateTime Time
        {
            get { return _inner.Time; }
            set { Set(TimeProperty, (t) => _inner.Time = t, _inner.Time, value); }
        }

        public bool Status
        {
            get { return _inner.Status; }
            set { Set(StatusProperty, (s) => _inner.Status = s, _inner.Status, value); }
        }

        public int Count
        {
            get { return _inner.Count; }
        }

        

        public DelegateSetterModel(int id)
        {
            PropertyChanged += OnPropertyChanged;
            _inner.DisplayText = "Lambda Model : " + id;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == StatusProperty)
            {
                _inner.Count += 1;
                RaisePropertyChanged(CountProperty);
            }
        }

        public static IDisplayText Create(int i)
        {
            return new DelegateSetterModel(i);
        }
    }
}
