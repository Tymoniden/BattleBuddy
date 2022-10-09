using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleBuddy.Base
{
    public class ViewModel : INotifyPropertyChanged
    {
        readonly Dictionary<string,object> _propertyValues = new ();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected TEntity? GetValue<TEntity>([CallerMemberName] string? propertyName = null)
        {
            if(propertyName == null)
            {
                return default;
            }

            if (_propertyValues.ContainsKey(propertyName))
            {
                return (TEntity) _propertyValues[propertyName];
            }

            return default;
        }

        protected void SetValue(object value, [CallerMemberName] string? propertyName = null)
        {
            if(propertyName == null)
            {
                return;
            }

            if (!_propertyValues.ContainsKey(propertyName))
            {
                _propertyValues.Add(propertyName, value);
                NotifyPropertyChanged(propertyName);
                return;
            }

            if (_propertyValues[propertyName].Equals(value))
            {
                return;
            }

            _propertyValues[propertyName] = value;
            NotifyPropertyChanged(propertyName);

        }

        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
