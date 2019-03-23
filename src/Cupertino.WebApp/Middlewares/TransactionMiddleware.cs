using System.Threading.Tasks;
using Cupertino.Core;
using Microsoft.AspNetCore.Http;

namespace Cupertino.WebApp.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate next;

        public TransactionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
        {
            await this.next(context);
            await unitOfWork.CommitAsync();
        }
    }
}
