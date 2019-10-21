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

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationContext _applicationContext;
        public UserManager<ApplicationUser> UserManager { get { return _userManager; } }

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationContext applicationContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationContext = applicationContext;
        }

        public async Task<ApplicationUser> GetAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> GetEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> GetNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> CreateAsync(ApplicationUser user)
        {
            bool succeeded = false;
            long userAuthors = _applicationContext.Users.Where(u => u.Email == user.Email).Count();
            if(userAuthors < 1)
            {
                var result = await _userManager.CreateAsync(user);
                succeeded = result.Succeeded;
                if (succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                }
            }
            return succeeded;
        }

        public async Task<Role> RoleCheckAsync(long userId)
        {
            long roleId = _applicationContext.UserRoles.FirstOrDefault(r => r.UserId == userId).RoleId;
            return await _applicationContext.Roles.FindAsync(roleId);
        }

        public async Task AddRoleAsync(long userId, string role)
        {
            var user = await _applicationContext.Users.FindAsync(userId);
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task RemoveAsync(ApplicationUser user)
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
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
            return result.Succeeded;
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {

            await _signInManager.SignInAsync(user, false);
        }
    }
}
