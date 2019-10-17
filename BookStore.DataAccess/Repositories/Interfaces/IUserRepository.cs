using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserManager<ApplicationUser> UserManager { get; }
        Task<ApplicationUser> GetAsync(string userId);
        Task<ApplicationUser> GetEmailAsync(string email);
        Task<ApplicationUser> GetUserNameAndPassword(string userName, string password);
        Task<bool> CreateAsync(ApplicationUser user);
        Task<Role> RoleCheckAsync(long userId);
        Task AddRoleAsync(long userId, string role);
        Task RemoveAsync(ApplicationUser user);
    }
}
