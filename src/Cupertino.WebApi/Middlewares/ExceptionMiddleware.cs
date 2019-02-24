using System;
using System.Threading.Tasks;
using Cupertino.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Http;

namespace Cupertino.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IErrorRepository errorRepository;

        public ExceptionMiddleware(
            RequestDelegate next,
            IErrorRepository errorRepository)
        {
            this.next = next;
            this.errorRepository = errorRepository;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch(Exception exception)
            {
                await this.errorRepository.LogAsync(exception);
            }
        }
    }
}
