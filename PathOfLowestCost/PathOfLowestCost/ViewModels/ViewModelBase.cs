using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PathOfLowestCost.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            var ev = PropertyChanged;
            ev?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
