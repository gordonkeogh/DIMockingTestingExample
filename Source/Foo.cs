namespace Source
{
    public class Foo
    {
        private readonly IDependency _dependency;
        
        public Foo(IDependency dependency)
        {
            _dependency = dependency;
        }

        public void DoSomething(string value)
        {
            _dependency.Value = value;
        }
    }
}
