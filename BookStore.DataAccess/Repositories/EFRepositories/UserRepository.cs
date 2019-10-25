using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.DataAccess.Models.UesrsFilterModel;
using Microsoft.EntityFrameworkCore;
using static BookStore.DataAccess.Models.Enums.Enums.UserFilterEnums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationContext _applicationContext;
        //public UserManager<ApplicationUser> UserManager { get { return _userManager; } }

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationContext applicationContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationContext = applicationContext;
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId) //Name GetByIdAsync
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> CreateAsync(ApplicationUser user)
        {
            //bool succeeded = false;
            var existingUser = await FindByEmailAsync(user.Email);
            if (user != null)
            {
                return false;
            }
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return result.Succeeded;
                //await _signInManager.SignInAsync(user, isPersistent: false);
            }
            result = await _userManager.AddToRoleAsync(user, "User"); //use const or enum
            return result.Succeeded;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task ConfirmEmailAsync(ApplicationUser user, string token)
        {
            await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task ResetPasswordAsync(ApplicationUser user,string token, string password)
        {
            await _userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<Role> CheckRoleAsync(long userId)
        {
            var identityRole = _applicationContext.UserRoles.Where(r => r.UserId == userId).FirstOrDefault();
            if (identityRole == null)
            {
                return null;
            }
            return await _applicationContext.Roles.FindAsync(identityRole.RoleId);
        }

        public async Task AddRoleAsync(long userId, string role)
        {
            var user = await _applicationContext.Users.FindAsync(userId);
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task RemoveAsync(ApplicationUser user) //change IsRemoved (update)
        {
            _applicationContext.Users.Remove(user);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> CheckUserAsync(ApplicationUser user, string password, bool lockoutOnFailure)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure:false);
            return result.Succeeded;
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync(UsersFilterModel usersFilter)
        {
            var users = _applicationContext.Users.AsQueryable(); //get only isn't removed
            if (!string.IsNullOrWhiteSpace(usersFilter.SearchString)) //to lowercase
            {
                users = users.Where(u => u.UserName == usersFilter.SearchString);
            }  
            if (usersFilter.UserStatus == UserStatus.Active)
            {
                users = users.Where(u => u.LockoutEnabled);
            }
            if (usersFilter.UserStatus == UserStatus.Blocked)
            {
                users = users.Where(u => !u.LockoutEnabled);
            }
            if(usersFilter.SortBy == SortBy.UserName)
            {
                users = users.OrderBy(u => u.UserName);
            }
            if(usersFilter.SortBy == SortBy.Email)
            {
                users = users.OrderBy(u => u.Email);
            }
            users = users.Skip((usersFilter.PageCount - 1) * usersFilter.PageSize).Take(usersFilter.PageSize);
            return await users.ToListAsync();
        }
    }
}
