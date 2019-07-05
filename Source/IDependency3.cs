using System.Threading.Tasks;

namespace Source
{
    public interface IDependency3
    {
        Task<bool> IsValid(string message);
    }
}
