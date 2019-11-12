using BookStore.BusinessLogic.Init;
using BookStore.DataAccess.Initialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using BookStore.Presentation.Helper;
using BookStore.Presentation.Helper.Interface;
using BookStore.Presentation.Middlewaren;
using Microsoft.OpenApi.Models;

namespace BookStore.Presentation
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
            services.AddControllers();
            Initializer.Init(services, Configuration.GetConnectionString("DefaultConnection"));
            //services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<IJwtHelper, JwtHelper>();
            //services.AddMvc();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAllOrigin", builder => builder.AllowAnyOrigin());
            //});
            services.AddCors();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());
            //});

            //services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication(options =>
            { 
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.Issuer,
                            ValidateAudience = true,
                            ValidAudience = AuthOptions.Audience,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddMvcCore().AddApiExplorer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseInitialization initializer, ILoggerFactory loggerFactory)
        {
            initializer.StartInit();
            app.UseCors(policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            //app.UseCors("CorsPolicy");

            app.UseMiddleware<ExceptionHandlerMiddleware>();    

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseAuthentication();                 
            //app.UseAuthorization();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
