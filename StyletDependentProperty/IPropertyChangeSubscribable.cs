namespace StyletDependentProperty
{
    using System;
    using System.Linq.Expressions;

    public interface IPropertyChangeSubscribable<TSelf> where TSelf : DependentPropertyChangedBase, IDependencyRegistrar
    {
        /// <summary>
        /// Specify a callback to run automatically when the given property changes.
        /// </summary>
        /// <param name="locator">The expression to find the property on an object of this type. Eg. myViewModel => myViewModel.SelectedItem</param>
        /// <param name="callback">The callback for the given property.</param>
        void OnChange<TDependencyProperty>(Expression<Func<TSelf, TDependencyProperty>> locator, Action callback);
    }
}