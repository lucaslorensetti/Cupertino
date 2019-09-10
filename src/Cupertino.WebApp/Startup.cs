using System.IO;
using Cupertino.Application.Services.Product;
using Cupertino.Core;
using Cupertino.Core.Common;
using Cupertino.Data.Contexts;
using Cupertino.Data.Entities;
using Cupertino.Data.Repositories;
using Cupertino.Data.UoW;
using Cupertino.WebApp.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Cupertino.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            // Contexts
            services.AddDbContext<IDbContext, SqlServerContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("CupertinoDb"));
            });

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IRepository<Product>, Repository<Product>>();

            // Services
            services.AddScoped<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMiddleware<TransactionMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Product", action = "List" });
            });
        }
    }
}
