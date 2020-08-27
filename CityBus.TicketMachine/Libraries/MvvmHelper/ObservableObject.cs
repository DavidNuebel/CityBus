using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CityBus.TicketMachine.Libraries.MvvmHelper
{
    class ObservableObject : INotifyPropertyChanged
    {
        public virtual void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
