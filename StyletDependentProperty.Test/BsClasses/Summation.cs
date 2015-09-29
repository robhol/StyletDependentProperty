namespace StyletDependentProperty.Test.BsClasses
{
    class Summation : DependentPropertyChangedBase<Summation>
    {
        private int _a;
        private int _b;

        public Summation()
        {
            DependOn(x => x.A).For(() => Sum);
            DependOn(x => x.B).For(() => Sum);
        }

        public int A
        {
            get { return _a; }
            set
            {
                _a = value;
                NotifyOfPropertyChange();
            }
        }

        public int B
        {
            get { return _b; }
            set
            {
                _b = value;
                NotifyOfPropertyChange();
            }
        }

        public int Sum => A + B;
    }
}