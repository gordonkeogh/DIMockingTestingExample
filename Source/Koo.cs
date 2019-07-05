using System;

namespace Source
{
    public class Koo
    {
        private readonly IDependency1 _dependency1;
        private readonly IDependency2 _dependency2;

        public Koo(IDependency1 dependency1, IDependency2 dependency2)
        {
            _dependency1 = dependency1;
            _dependency2 = dependency2;
        }

        public void DoSomething(string message)
        {
            try
            {
                var valueIsValid = _dependency1.IsValid(message);

                if (valueIsValid)
                {
                    _dependency2.Send(message);
                }
            }
            catch (Exception e)
            {
                throw new KooException("An exception occurred whilst doing something", e);
            }
        }
    }
}