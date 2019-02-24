using System;
using System.Threading.Tasks;
using Cupertino.Core;
using Cupertino.Data.Entities;

namespace Cupertino.Data.Repositories.Contracts
{
    public interface IErrorRepository : IRepository<Error>
    {
        Task LogAsync(Exception exception);
    }
}
