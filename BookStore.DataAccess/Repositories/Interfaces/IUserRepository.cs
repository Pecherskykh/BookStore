using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.UesrsFilterModel;
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
        Task<ApplicationUser> GetNameAsync(string userName);
        Task<bool> CreateAsync(ApplicationUser user);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task RemoveAsync(ApplicationUser user);
        Task<Role> RoleCheckAsync(long userId);
        Task AddRoleAsync(long userId, string role);
        Task<bool> CheckUserAsync(ApplicationUser user, string password, bool lockoutOnFailure);
        Task SignInAsync(ApplicationUser user, bool isPersistent);
        Task<IEnumerable<ApplicationUser>> GetUsersAsync(UsersFilter usersFilter);
    }
}
