using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Cupertino.Core.Common.CQRS;

namespace Cupertino.Application.Common.CQRS
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider provider;

        public Dispatcher(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task<TResult> ExecuteAsync<TResult>(ICommand command)
            where TResult : IResult
        {
            var type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            var handlerType = type.MakeGenericType(typeArgs);

            if (this.provider.GetService(handlerType) is ICommandHandler<ICommand> handler)
            {
                return await handler.HandleAsync<TResult>(command);
            }

            if (Result.Fail($"There is no {nameof(ICommandHandler<ICommand>)}.") is TResult result)
            {
                return result;
            }

            return default;
        }

        public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
            where TResult : class
        {
            var type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(TResult) };
            var handlerType = type.MakeGenericType(typeArgs);

            if (this.provider.GetService(handlerType) is IQueryHandler<IQuery<TResult>, TResult> handler)
            {
                return await handler.HandleAsync(query);
            }

            return default;
        }
    }
}
