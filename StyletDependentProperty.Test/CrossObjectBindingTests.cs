namespace StyletDependentProperty.Test
{
    using System;
    using System.Linq.Expressions;
    using BsClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CrossObjectBindingTests : DependencyTestFixture
    {
        [TestMethod]
        public void BindOther()
        {
            var foo = new Foo("123");
            var bar = new Bar(foo);

            AssertChange(foo, bar, x => x.FooDependentValue, () => foo.Value = "arbitrary");
        }
    }
}