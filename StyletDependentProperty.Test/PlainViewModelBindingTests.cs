namespace StyletDependentProperty.Test
{
    using BsClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlainViewModelBindingTests : DependencyTestFixture
    {
        [TestMethod]
        public void BindPlainViewModelProperty()
        {
            var vm = new PlainViewModel();
            var dependent = new PlainViewModelDependent(vm);
            
            AssertChange(vm, dependent, x => x.DependentProperty, () => vm.Property = "");
        }
    }
}