using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public class DelegateSetterBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool Set<T>(string propertyName, Action<T> setter, T field, T value)
        {
            if (field == null || EqualityComparer<T>.Default.Equals(field, value)) { return false; }
            setter(value);
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
