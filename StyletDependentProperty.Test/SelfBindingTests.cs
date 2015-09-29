namespace StyletDependentProperty.Test
{
    using BsClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SelfBindingTests : DependencyTestFixture
    {
        [TestMethod]
        public void BindSelfProperty()
        {
            var foo = new Foo("123");

            AssertChange(foo, x => x.CalculatedValue, () => foo.Value = "arbitrary");
        }

        [TestMethod]
        public void FireOnChangeForSelfProperty()
        {
            var foo = new Foo("123");
            var fired = false;
            foo.OwnValueChangedEvent += () => fired = true;
            foo.Value = "arbitrary";

            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void DoNotBindUnrelatedSelfProperty()
        {
            var foo = new Foo("123");

            AssertChange(foo, x => x.UnrelatedValue, () => foo.Value = "arbitrary", false);
        }

        [TestMethod]
        public void DoNotFireOnChangeForUnrelatedSelfProperty()
        {
            var foo = new Foo("123");
            var fired = false;
            foo.OwnValueChangedEvent += () => fired = true;
            foo.UnrelatedValue = "arbitrary";

            Assert.IsFalse(fired);
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