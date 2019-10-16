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

        public UserRepository()
        {

        }

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetAsync(long userId)
        {
            await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task CreateAsync(ApplicationUser user)
        {
            long userAuthors = _applicationContext.Users.Where(u => u.Email == user.Email).Count();
            if(userAuthors < 1)
            {
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                }
            }
        }

        public async Task RoleCheckAsync(long userId)
        {
            long roleId = _applicationContext.UserRoles.FirstOrDefault(r => r.UserId == userId).RoleId;
            await _applicationContext.Roles.FindAsync(roleId);
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
    }
}
