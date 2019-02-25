using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cupertino.WebApp
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseRewriter();

            ForceLoadIndex(app);

            app.UseStaticFiles();

            ForceRedirectToIndex(app);
        }

        private static void ForceRedirectToIndex(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                if (!context.Request.Path.Value.StartsWith("/vendor"))
                {
                    context.Response.Redirect("/");
                }

                return Task.FromResult(0);
            });
        }

        private static void ForceLoadIndex(IApplicationBuilder app)
        {
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
        }
    }
}
