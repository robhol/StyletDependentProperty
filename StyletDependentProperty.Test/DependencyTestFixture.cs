namespace StyletDependentProperty.Test
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class DependencyTestFixture
    {
        protected void AssertChange<TDependency, TDependent>(TDependency master, TDependent slave, Expression<Func<TDependent, object>> property, Action when, bool shouldHappen = true)
            where TDependency : DependentPropertyChangedBase
            where TDependent : DependentPropertyChangedBase
        {
            var changed = false;
            var propName = DependencyHelper.GetPropertyAccessorName(property);

            slave.PropertyChanged += (sender, args) => { changed |= args.PropertyName == propName; };

            when();
            Assert.AreEqual(shouldHappen, changed);
        }

        protected void AssertChange<TViewModel>(TViewModel self, Expression<Func<TViewModel, object>> property, Action when, bool shouldHappen = true)
            where TViewModel : DependentPropertyChangedBase
            => AssertChange(self, self, property, when, shouldHappen);
    }
}