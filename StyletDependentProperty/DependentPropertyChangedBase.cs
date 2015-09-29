namespace StyletDependentProperty
{
    using System;
    using System.ComponentModel;
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
            Expression<Func<TDependentProperty>> dependentLocator) where TDependencyViewModel : class, INotifyPropertyChanged
        {
            dependencyViewModel.Bind(dependencyLocator, (_, __) => { NotifyOfPropertyChange(dependentLocator); });
        }

        /// <summary>
        /// Specify a callback to run automatically when the given property changes.
        /// </summary>
        /// <param name="locator">The expression to find the property on an object of this type. Eg. myViewModel => myViewModel.SelectedItem</param>
        /// <param name="callback">The callback for the given property.</param>
        public void OnChange<TDependencyProperty>(Expression<Func<TSelf, TDependencyProperty>> locator, Action callback)
        {
            var name = DependencyHelper.GetPropertyAccessorName(locator);
            Myself.Bind(locator, (sender, args) =>
            {
                if (args.PropertyName == name)
                    callback();
            });
        }

        /// <summary>
        /// Specify that the given property depends on another to be specified in a call to For.
        /// </summary>
        /// <param name="dependencyLocator">The expression to find the property on an object of this type. Eg. myViewModel => myViewModel.SelectedItem</param>
        protected IDependentPropertyLocator<TSelf> DependOn<TDependencyProperty>(
            Expression<Func<TSelf, TDependencyProperty>> dependencyLocator)
        {
            return new DependencyBuilder<TSelf, TDependencyProperty, TSelf>(Myself, Myself, dependencyLocator);
        }

        /// <summary>
        /// Specify that the given property depends on a property from a different viewmodel, to be specified in a call to For.
        /// </summary>
        /// <param name="dependencyViewModel">The viewmodel containing the property.</param>
        /// <param name="dependencyLocator">The expression to find the property on an object of the viewmodel's type. Eg. myViewModel => myViewModel.SelectedItem</param>
        protected IDependentPropertyLocator<TSelf> DependOn<TDependencyViewModel, TDependencyProperty>(
            TDependencyViewModel dependencyViewModel,
            Expression<Func<TDependencyViewModel, TDependencyProperty>> dependencyLocator)
            where TDependencyViewModel : class, INotifyPropertyChanged
        {
            return new DependencyBuilder<TDependencyViewModel, TDependencyProperty, TSelf>(Myself, dependencyViewModel, dependencyLocator);
        }
    }
}