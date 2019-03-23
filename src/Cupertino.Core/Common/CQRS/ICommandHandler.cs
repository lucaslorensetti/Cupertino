using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Cupertino.Core.Common.CQRS
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task<TResult> HandleAsync<TResult>(TCommand command)
            where TResult : IResult;
    }
}
