using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Wpf.Models
{
    public class Field2Model : FieldBase, IDisplayText
    {
        public static readonly string TimeProperty;
        public static readonly string StatusProperty;
        public static readonly string CountProperty;
        public static readonly string DisplayTextProperty;

        static Field2Model()
        {
            var dummy = new Field2Model(0);

            TimeProperty = GetPropertyName(() => dummy.Time);
            StatusProperty = GetPropertyName(() => dummy.Status);
            CountProperty = GetPropertyName(() => dummy.Count);
            DisplayTextProperty = GetPropertyName(() => dummy.DisplayText);
        }

        private static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }

        private readonly Field<string> _displayText = new Field<string>(DisplayTextProperty);
        public string DisplayText
        {
            get { return _displayText; }
        }

        private readonly Field<DateTime> _time = new Field<DateTime>(TimeProperty);
        public DateTime Time
        {
            get { return _time; }
            set { Set(_time, value); }
        }

        private readonly Field<bool> _status = new Field<bool>(StatusProperty);
        public bool Status
        {
            get { return _status; }
            set { Set(_status, value); }
        }

        private readonly Field<int> _count = new Field<int>(CountProperty);
        public int Count
        {
            get { return _count; }
        }

        public Field2Model(int id)
        {
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
            return new Field2Model(i);
        }
    }
}
