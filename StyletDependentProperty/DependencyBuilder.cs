namespace StyletDependentProperty
{
    using System;
    using System.Linq.Expressions;

    internal class DependencyBuilder<TDependencyViewModel, TDependencyProperty, TSelf> : IDependentPropertyLocator<TSelf>
        where TSelf : IDependencyRegistrar
        where TDependencyViewModel : DependentPropertyChangedBase
    {
        private readonly Expression<Func<TDependencyViewModel, TDependencyProperty>> _dependencyLocator;
        private readonly TDependencyViewModel _dependencyViewModel;
        private readonly TSelf _dependentViewModel;

        public DependencyBuilder(TSelf dependentViewModel, TDependencyViewModel dependencyViewModel,
            Expression<Func<TDependencyViewModel, TDependencyProperty>> dependencyLocator)
        {
            _dependentViewModel = dependentViewModel;
            _dependencyViewModel = dependencyViewModel;
            _dependencyLocator = dependencyLocator;
        }

        public void For<TDependentProperty>(Expression<Func<TDependentProperty>> dependentLocator)
        {
            _dependentViewModel.RegisterDependency(_dependencyViewModel, _dependencyLocator, dependentLocator);
        }

        public void For<TDependentProperty>(Expression<Func<TSelf, TDependentProperty>> dependentLocator)
        {
            var adjustedDependentLocator = DependencyHelper.ToNonParametricFuncExpression(dependentLocator, _dependentViewModel);
            _dependentViewModel.RegisterDependency(_dependencyViewModel, _dependencyLocator, adjustedDependentLocator);
        }
    }
}