using BookStore.BusinessLogic.Helpers;
using BookStore.BusinessLogic.Helpers.Interfaces;
using BookStore.BusinessLogic.Services;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Initialization;
using BookStore.DataAccess.Repositories.EFRepositories;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.BusinessLogic.Init
{
    public class Initializer
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<RoleManager<Role>>();
            services.AddTransient<DataBaseInitialization>();

            services.AddTransient<IEmailHelper, EmailHelper>();
            services.AddTransient<IConvertCurrencyHelper, ConvertCurrencyHelper>();
            services.AddTransient<ICreatePasswordHelper, CreatePasswordHelper>();

            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IAuthorRepository, AuthorRepository>();

            services.AddTransient<IAuthorRepository, DataAccess.Repositories.DapperRepositories.AuthorRepository>();

            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderRepository, DataAccess.Repositories.DapperRepositories.OrderRepository>();

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddTransient<IAuthorInPrintingEditionRepository, AuthorInPrintingEditionRepository>();
            services.AddTransient<TestDapper, DataAccess.Repositories.DapperRepositories.UserRepository>();

            services.AddTransient<IAccountServise, AccountService>();            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthorService, AuthorService>();            
            services.AddTransient<IPrintingEditorService, PrintingEditorService>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
