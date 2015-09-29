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

    class PlainViewModelDependent : DependentPropertyChangedBase<PlainViewModelDependent>
    {
        private readonly PlainViewModel _plainViewModel;

        public string DependentProperty => _plainViewModel.Property;

        public PlainViewModelDependent(PlainViewModel plainViewModel)
        {
            _plainViewModel = plainViewModel;
            DependOn(plainViewModel, model => model.Property).For(() => DependentProperty);
        }
    }
}
