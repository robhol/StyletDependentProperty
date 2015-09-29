using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletDependentProperty.Test.BsClasses
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;

    class PlainViewModel : INotifyPropertyChanged
    {
        private string _property;

        public string Property
        {
            get { return _property; }
            set
            {
                if (value == _property) return;
                _property = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
