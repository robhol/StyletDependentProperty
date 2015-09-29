namespace StyletDependentProperty
{
    using System;
    using System.Linq.Expressions;

    public interface IDependentPropertyLocator<TSelf>
    {
        void For<TTarget>(Expression<Func<TTarget>> dependentLocator);
        void For<TTarget>(Expression<Func<TSelf, TTarget>> dependentLocator);
    }
}