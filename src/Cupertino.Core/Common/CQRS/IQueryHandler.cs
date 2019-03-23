using System.Threading.Tasks;

namespace Cupertino.Core.Common.CQRS
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
