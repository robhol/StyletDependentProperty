namespace StyletDependentProperty
{
    using System;
    using System.Linq.Expressions;

    public interface IDependentPropertyLocator<TSelf>
    {
        /// <summary>
        /// Specifies the dependent/automatically changing property.
        /// </summary>
        /// <param name="dependentLocator"></param>
        void For<TTarget>(Expression<Func<TTarget>> dependentLocator);
        /// <summary>
        /// Specifies the dependent/automatically changing property.
        /// </summary>
        /// <param name="dependentLocator"></param>
        void For<TTarget>(Expression<Func<TSelf, TTarget>> dependentLocator);
    }
}