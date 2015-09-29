namespace StyletDependentProperty
{
    using System;
    using System.Linq.Expressions;
    using Stylet;

    public abstract class DependentPropertyChangedBase : PropertyChangedBase
    {
    }

    public class DependentPropertyChangedBase<TSelf> : DependentPropertyChangedBase, IDependencyRegistrar, IPropertyChangeSubscribable<TSelf>
        where TSelf : DependentPropertyChangedBase, IDependencyRegistrar
    {
        private TSelf Myself => this as TSelf;

        public void RegisterDependency<TDependencyViewModel, TDependencyProperty, TDependentProperty>(
            TDependencyViewModel dependencyViewModel,
            Expression<Func<TDependencyViewModel, TDependencyProperty>> dependencyLocator,
            Expression<Func<TDependentProperty>> dependentLocator) where TDependencyViewModel : PropertyChangedBase
        {
            dependencyViewModel.Bind(dependencyLocator, (_, __) => { NotifyOfPropertyChange(dependentLocator); });
        }

        public void OnChange<TDependencyProperty>(Expression<Func<TSelf, TDependencyProperty>> locator, Action callback)
        {
            var name = DependencyHelper.GetPropertyAccessorName(locator);
            Myself.Bind(locator, (sender, args) =>
            {
                if (args.PropertyName == name)
                    callback();
            });
        }

        protected IDependentPropertyLocator<TSelf> DependOn<TDependencyProperty>(
            Expression<Func<TSelf, TDependencyProperty>> dependencyLocator)
        {
            return new DependencyBuilder<TSelf, TDependencyProperty, TSelf>(Myself, Myself, dependencyLocator);
        }

        protected IDependentPropertyLocator<TSelf> DependOn<TDependencyViewModel, TDependencyProperty>(
            TDependencyViewModel dependencyViewModel,
            Expression<Func<TDependencyViewModel, TDependencyProperty>> dependencyLocator)
            where TDependencyViewModel : DependentPropertyChangedBase
        {
            return new DependencyBuilder<TDependencyViewModel, TDependencyProperty, TSelf>(Myself, dependencyViewModel, dependencyLocator);
        }
    }
}