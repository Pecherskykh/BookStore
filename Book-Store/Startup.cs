using BookStore.BusinessLogic.Init;
using BookStore.DataAccess.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Book_Store.Middlewaren;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BookStore.BusinessLogic.Helpers;

namespace Book_Store
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            Initializer.Init(services, Configuration.GetConnectionString("DefaultConnection"));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<EmailHelper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseInitialization initializer, ILoggerFactory loggerFactory, EmailHelper mailMessage)
        {
            initializer.StartInit();

            mailMessage.Send();
            app.UseMiddleware<ExceptionHandlerMiddleware>();    

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
