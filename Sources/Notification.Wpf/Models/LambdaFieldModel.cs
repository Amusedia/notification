using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Wpf.Models
{
    public class LambdaFieldModel : LambdaFieldBase, IDisplayText
    {
        private readonly Field<string> _displayText;
        public string DisplayTextProperty { get { return _displayText.PropertyName; } }
        public string DisplayText
        {
            get { return _displayText; }
        }

        private readonly Field<DateTime> _time;
        public string TimeProperty { get { return _time.PropertyName; } }
        public DateTime Time
        {
            get { return _time; }
            set { Set(_time, value); }
        }

        private readonly Field<bool> _status;
        public string StatusProperty { get { return _status.PropertyName; } }
        public bool Status
        {
            get { return _status; }
            set { Set(_status, value); }
        }

        private readonly Field<int> _count;
        public string CountProperty { get { return _count.PropertyName; } }
        public int Count
        {
            get { return _count; }
        }

        public LambdaFieldModel(int id)
        {
            _displayText = new Field<string>(() => DisplayText);
            _time = new Field<DateTime>(() => Time);
            _status = new Field<bool>(() => Status);
            _count = new Field<int>(() => Count);
            PropertyChanged += OnPropertyChanged;
            _displayText.Value = "Setter Model : " + id;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == StatusProperty)
            {
                Set(_count, _count + 1);
            }
        }

        public static IDisplayText Create(int i)
        {
            return new LambdaFieldModel(i);
        }
    }
}
