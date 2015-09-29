using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletDependentProperty.Test.BsClasses
{
    using System.Linq.Expressions;

    class Foo : DependentPropertyChangedBase<Foo>
    {
        private string _value;

        public Foo(string value)
        {
            _value = value;
            DependOn(x => x.Value).For(() => CalculatedValue);

            ParameterlessAccessorExpression = () => Value;
        }

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyOfPropertyChange();
            }
        }

        public string CalculatedValue => Value.ToLower();
        public string UnrelatedValue { get; } = "unrelated";
        public Expression<Func<string>> ParameterlessAccessorExpression { get; }
    }
}
