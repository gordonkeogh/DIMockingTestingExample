using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]
namespace Source
{
    public class Bar
    {
        public string DoSomething(string message)
        {
            return IsValid(message) ? "Valid" : "Invalid";
        }

        protected internal virtual bool IsValid(string message)
        {
            return !string.IsNullOrEmpty(message);
        }
    }
}