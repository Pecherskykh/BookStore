using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IAccountServise
    {
        Task<ApplicationUser> GetAsync(string userId);
        Task<ApplicationUser> GetEmailAsync(string email);
        Task<ApplicationUser> GetNameAsync(string userName);
        Task<bool> CreateAsync(ApplicationUser user);
        Task<Role> RoleCheckAsync(long userId);
        Task AddRoleAsync(long userId, string role);
        Task RemoveAsync(ApplicationUser user);
        Task Register();
        Task ConfirmEmail(string userId, string token);
        Task ForgotPassword();
        Task ResetPassword(string userId, string token, string password);
        Task<bool> CheckUserAsync(ApplicationUser user, string password, bool lockoutOnFailure);
        Task SignInAsync(ApplicationUser user, bool isPersistent);
    }
}
