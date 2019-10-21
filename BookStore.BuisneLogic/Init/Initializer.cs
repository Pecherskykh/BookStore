using BookStore.BusinessLogic.Services;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Initialization;
using BookStore.DataAccess.Repositories.EFRepositories;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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

            services.AddTransient<IAccountServise, AccountService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
        }
    }
}
