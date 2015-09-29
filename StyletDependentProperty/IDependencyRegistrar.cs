namespace StyletDependentProperty
{
    using System;
    using System.Linq.Expressions;
    using Stylet;

    public interface IDependencyRegistrar
    {
        void RegisterDependency<TDependencyViewModel, TDependencyProperty, TDependentProperty>(
            TDependencyViewModel dependencyViewModel,
            Expression<Func<TDependencyViewModel, TDependencyProperty>> dependencyLocator,
            Expression<Func<TDependentProperty>> dependentLocator)
            where TDependencyViewModel : PropertyChangedBase;
    }
}