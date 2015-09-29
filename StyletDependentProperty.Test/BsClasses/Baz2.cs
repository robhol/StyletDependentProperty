namespace StyletDependentProperty.Test.BsClasses
{
    class Baz2 : DependentPropertyChangedBase<Baz2>
    {
        private readonly Baz _baz;

        public Baz2(Baz baz)
        {
            _baz = baz;
            DependOn(baz, x => x.Asd).For(my => my.Jkl);
        }

        public string Jkl => _baz.Asd.ToUpper();
    }
}