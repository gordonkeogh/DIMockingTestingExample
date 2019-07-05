using System.Threading.Tasks;

namespace Source
{
    public class Roo
    {
        private readonly IDependency3 _dependency;

        public Roo(IDependency3 dependency)
        {
            _dependency = dependency;
        }

        public async Task<bool> DoSomething(string message)
        {
            return await _dependency.IsValid(message);
        }
    }
}