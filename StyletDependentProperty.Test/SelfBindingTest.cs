namespace StyletDependentProperty.Test
{
    using BsClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SelfBindingTest : DependencyTestFixture
    {
        [TestMethod]
        public void BindSelfProperty()
        {
            var foo = new Foo("123");

            AssertChange(foo, x => x.CalculatedValue, () => foo.Value = "arbitrary");
        }

        [TestMethod]
        public void UnrelatedSelfProperty()
        {
            var foo = new Foo("123");

            AssertChange(foo, x => x.UnrelatedValue, () => foo.Value = "arbitrary", false);
        }

        [TestMethod]
        public void BindDualSelfProperty()
        {
            var summation = new Summation();

            AssertChange(summation, x => x.Sum, () => summation.A = 1);
            AssertChange(summation, x => x.Sum, () => summation.B = 1);
        }

        [TestMethod]
        public void BindSelfPropertyIdentifiedByParametricExpression()
        {
            var baz = new Baz();
            AssertChange(baz, x => x.Fgh, () => baz.Asd = "arbitrary");
        }
    }
}