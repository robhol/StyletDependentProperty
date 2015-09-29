namespace StyletDependentProperty.Test.BsClasses
{
    class Bar : DependentPropertyChangedBase<Bar>
    {
        private readonly Foo _foo;

        public Bar(Foo foo)
        {
            _foo = foo;
            DependOn(foo, x => x.Value).For(() => FooDependentValue);
        }

        public string FooDependentValue => _foo.Value.ToUpper();
        public string UnrelatedValue { get; } = "unrelated";
    }
}