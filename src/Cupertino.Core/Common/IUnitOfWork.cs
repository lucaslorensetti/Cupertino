using System.Threading.Tasks;

namespace Cupertino.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
