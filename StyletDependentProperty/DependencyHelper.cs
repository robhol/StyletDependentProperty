namespace StyletDependentProperty
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal static class DependencyHelper
    {
        public static Expression<Func<TOut>> ToNonParametricFuncExpression<TIn, TOut>(Expression<Func<TIn, TOut>> parametricExpression, TIn inValue)
        {
            var propertyName = ((parametricExpression.Body as MemberExpression)?.Member)?.Name;

            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException(nameof(parametricExpression));

            return Expression.Lambda<Func<TOut>>(Expression.PropertyOrField(Expression.Constant(inValue, typeof (TIn)), propertyName));
        }

        public static string GetPropertyAccessorName(Expression x)
        {
            string name = null;

            while (true)
            {
                if (x is MemberExpression)
                {
                    name = ((MemberExpression) x).Member.Name;
                    break;
                }

                if (x is LambdaExpression)
                {
                    x = ((LambdaExpression) x).Body;
                    continue;
                }

                if (x is MethodCallExpression)
                {
                    x = ((MethodCallExpression) x).Arguments.First();
                    continue;
                }

                if (x is UnaryExpression)
                {
                    x = ((UnaryExpression) x).Operand;
                    continue;
                }

                throw new ArgumentException(x.GetType().GetFriendlyName());
            }

            return name;
        }

        public static string GetPropertyAccessorName<T>(Expression<Func<T>> e) => GetPropertyAccessorName(e.Body);
        public static string GetPropertyAccessorName<T1, T2>(Expression<Func<T1, T2>> e) => GetPropertyAccessorName(e.Body);
    }
}