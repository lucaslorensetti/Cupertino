using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Cupertino.Core.Common.CQRS
{
    public interface IDispatcher
    {
        Task<TResult> ExecuteAsync<TResult>(ICommand command)
            where TResult : IResult;

        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
            where TResult : class;
    }
}
