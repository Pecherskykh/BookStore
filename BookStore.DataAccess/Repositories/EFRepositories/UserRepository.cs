using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.DataAccess.Models.UesrsFilterModel;
using Microsoft.EntityFrameworkCore;
using BookStore.DataAccess.Extensions;
using static BookStore.DataAccess.Models.Enums.Enums;
using static BookStore.DataAccess.Entities.Enums.Enums;
using BookStore.DataAccess.Models.Users;
using System;

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

        public async Task<bool> CreateAsync(ApplicationUser user, string password)
        {
            var existingUser = await FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return false;
            }
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return result.Succeeded;
            }
            result = await _userManager.AddToRoleAsync(user, RoleEnum.User.ToString());
            return result.Succeeded;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
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
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }

        public async Task<bool> ResetPasswordAsync(ApplicationUser user,string token, string password)
        {
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            return result.Succeeded;
        }

        public async Task<string> CheckRoleAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var identityRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();      
            return identityRole;
        }

        public async Task<bool> RemoveAsync(ApplicationUser user)
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

        public async Task SignInAsync(ApplicationUser user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<UserModel> GetUsersAsync(UsersFilterModel usersFilter)
        {
            var resultModel = new UserModel();

            var users = _applicationContext.Users.Where(u => !u.IsRemoved && u.Id != 40).AsQueryable();

            if (!string.IsNullOrWhiteSpace(usersFilter.SearchString))
            {
                users = SearchUser(usersFilter.SearchString, users);
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

            resultModel.Count = users.Count();
            
            users = users.Skip(usersFilter.PageCount * usersFilter.PageSize).Take(usersFilter.PageSize);

            resultModel.Items = await users.ToListAsync();

            return resultModel;
        }

        private IQueryable<ApplicationUser> SearchUser(string searchString, IQueryable<ApplicationUser> users)
        {
            string[] words = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 1)
            {
                users = users.Where(u =>
                    u.FirstName.Substring(0, words[0].Length).ToLower().Contains(words[0].ToLower()) ||
                    u.LastName.Substring(0, words[0].Length).ToLower().Contains(words[0].ToLower())
                );
            }
            if (words.Length == 2)
            {
                users = users.Where(u =>
                    (u.FirstName.Substring(0, words[0].Length).ToLower().Contains(words[0].ToLower()) ||
                    u.LastName.Substring(0, words[0].Length).ToLower().Contains(words[0].ToLower())) &&
                    (u.FirstName.Substring(0, words[1].Length).ToLower().Contains(words[1].ToLower()) ||
                    u.LastName.Substring(0, words[1].Length).ToLower().Contains(words[1].ToLower()))
                );
            }
            return users;
        }
    }
}
