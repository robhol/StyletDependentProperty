namespace StyletDependentProperty.Test
{
    using System;
    using System.Linq.Expressions;
    using BsClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PropertyLambdaTests
    {
        public object Derp { get; } = null;

        [TestMethod]
        public void FindPropertyAccessorName()
        {
            var foo = new Foo("123");
            Assert.AreEqual("Value", DependencyHelper.GetPropertyAccessorName((Foo x) => x.Value));
            Assert.AreEqual("Derp", DependencyHelper.GetPropertyAccessorName(() => Derp));
        }

        [TestMethod]
        public void DeparameterizeExpression()
        {
            Expression<Func<Foo, string>> fooParameterizedAccessor = x => x.Value;

            var foo = new Foo("abc");

            Assert.AreEqual(
                foo.ParameterlessAccessorExpression.ToString(),
                DependencyHelper.ToNonParametricFuncExpression(fooParameterizedAccessor, foo).ToString());
        }

    }
}