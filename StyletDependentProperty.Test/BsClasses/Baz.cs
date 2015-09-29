namespace StyletDependentProperty.Test.BsClasses
{
    class Baz : DependentPropertyChangedBase<Baz>
    {
        private string _asd;

        public Baz()
        {
            DependOn(x => x.Asd).For(x => x.Fgh);
        }

        public string Asd
        {
            get { return _asd; }
            set
            {
                _asd = value;
                NotifyOfPropertyChange();
            }
        }

        public string Fgh => Asd.ToLower();
    }
}