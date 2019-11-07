using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.DataAccess.Models.UesrsFilterModel;
using Microsoft.EntityFrameworkCore;
using BookStore.DataAccess.Extensions;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationContext _applicationContext;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationContext applicationContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationContext = applicationContext;
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
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
            var existingUser = await FindByEmailAsync(user.Email); //todo chack existing User fro null
            if (user == null) //todo check this
            {
                return false;
            }
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return result.Succeeded;
            }
            result = await _userManager.AddToRoleAsync(user, "User"); //todo use const or enum
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

        public async Task<bool> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token); //todo return result
            return result.Succeeded;
        }

        public async Task<bool> ResetPasswordAsync(ApplicationUser user,string token, string password)
        {
            var result = await _userManager.ResetPasswordAsync(user, token, password); //todo return result
            return result.Succeeded;
        }

        public async Task<string> CheckRoleAsync(string userId) //todo return string
        {
            var user = await _userManager.FindByIdAsync(userId);
            var identityRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault(); //todo user userManager            
            return identityRole;
        }

        public async Task<bool> RemoveAsync(ApplicationUser user) //todo change IsRemoved pro with UserManager
        {
            user.IsRemoved = true;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UpdateAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> CheckUserAsync(ApplicationUser user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure:false);
            return result.Succeeded;
        }

        public async Task SignInAsync(ApplicationUser user) //todo remove isPersistent param
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync(UsersFilterModel usersFilter)
        {
            var users = _applicationContext.Users.Where(u => !u.IsRemoved).AsQueryable();
            if (!string.IsNullOrWhiteSpace(usersFilter.SearchString))
            {
                users = users.Where(u => u.UserName.ToLower().Equals(usersFilter.SearchString.ToLower()));
            }  
            if (usersFilter.UserStatus == UserStatus.Active)
            {
                users = users.Where(u => u.LockoutEnabled);
            }
            if (usersFilter.UserStatus == UserStatus.Blocked)
            {
                users = users.Where(u => !u.LockoutEnabled);
            }
            if(usersFilter.SortType == UserSortType.UserName)
            {
                users = users.OrderDirection(u => u.UserName, usersFilter.SortingDirection == SortingDirection.LowToHigh);
            }
            if(usersFilter.SortType == UserSortType.Email)
            {
                users = users.OrderDirection(u => u.Email, usersFilter.SortingDirection == SortingDirection.LowToHigh);
            }
            users = users.Skip((usersFilter.PageCount - 1) * usersFilter.PageSize).Take(usersFilter.PageSize);
            return await users.ToListAsync();
        }
    }
}
