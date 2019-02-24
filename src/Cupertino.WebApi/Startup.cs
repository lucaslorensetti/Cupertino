using Cupertino.Core.Common;
using Cupertino.Data.Contexts;
using Cupertino.Data.Repositories;
using Cupertino.Data.Repositories.Contracts;
using Cupertino.Services;
using Cupertino.Services.Contracts;
using Cupertino.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cupertino.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            // Contexts
            services.AddDbContext<IDbContext, SqlServerContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("CupertinoDb"));
            });

            // Repositories
            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

        }
    }
}
