using System;
using System.Threading.Tasks;
using Cupertino.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Http;

namespace Cupertino.WebApp.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IErrorRepository errorRepository)
        {
            try
            {
                await this.next(context);
            }
            catch(Exception exception)
            {
                await errorRepository.LogAsync(exception);
            }
        }
    }
}
