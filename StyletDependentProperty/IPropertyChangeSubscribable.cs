namespace StyletDependentProperty
{
    using System;
    using System.Linq.Expressions;

    public interface IPropertyChangeSubscribable<TSelf> where TSelf : DependentPropertyChangedBase, IDependencyRegistrar
    {
        void OnChange<TDependencyProperty>(Expression<Func<TSelf, TDependencyProperty>> locator, Action callback);
    }
}