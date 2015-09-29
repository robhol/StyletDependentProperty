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
            OnChange(x => x.Value, () => OwnValueChangedEvent());

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
        public string UnrelatedValue { get; set; } = "unrelated";
        public Expression<Func<string>> ParameterlessAccessorExpression { get; }

        public event Action OwnValueChangedEvent = () => { ; };
    }
}
