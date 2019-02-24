using System.Threading.Tasks;
using Cupertino.Core;
using Microsoft.AspNetCore.Http;

namespace Cupertino.WebApi.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IUnitOfWork unitOfWork;

        public TransactionMiddleware(
            RequestDelegate next, 
            IUnitOfWork unitOfWork)
        {
            this.next = next;
            this.unitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await this.next(context);
            await this.unitOfWork.CommitAsync();
        }
    }
}
