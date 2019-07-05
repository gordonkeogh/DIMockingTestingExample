namespace Source
{
    public class Goo
    {
        private readonly IDependency1 _dependency1;
        private readonly IDependency2 _dependency2;

        public Goo(IDependency1 dependency1, IDependency2 dependency2)
        {
            _dependency1 = dependency1;
            _dependency2 = dependency2;
        }

        public void DoSomething(string message)
        {
            var valueIsValid = _dependency1.IsValid(message);

            if (valueIsValid)
            {
                _dependency2.Send(message);
            }
        }
    }
}
