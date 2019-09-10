using System.Threading.Tasks;
using Cupertino.Core;
using Microsoft.AspNetCore.Http;

namespace Cupertino.WebApp.Middlewares
{
    public class TransactionMiddleware
    {
        private RequestDelegate next;

        public TransactionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            await this.next.Invoke(context);
            await unitOfWork.CommitAsync();
        }
    }
}
