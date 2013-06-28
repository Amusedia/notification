using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public abstract class LambdaFieldBase : INotifyPropertyChanged
    {
        protected class Field<T>
        {
            public string PropertyName;
            public T Value;

            public Field(Expression<Func<T>> expression)
            {
                PropertyName = GetPropertyName(expression);
            }

            protected string GetPropertyName<T>(Expression<Func<T>> expression)
            {
                MemberExpression memberExpression = (MemberExpression)expression.Body;
                return memberExpression.Member.Name;
            }

            public static implicit operator T(Field<T> t)
            {
                return t.Value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        protected bool Set<T>(Field<T> field, T value)
        {
            if (field == null || EqualityComparer<T>.Default.Equals(field.Value, value)) return false;
            field.Value = value;
            RaisePropertyChanged(field.PropertyName);
            return true;
        }
    }
}
