using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.UesrsFilterModel;
using BookStore.DataAccess.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateAsync(ApplicationUser user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<ApplicationUser> GetAsync(string userId)
        {
            return await _userRepository.GetAsync(userId);
        }

        public async Task<Role> RoleCheckAsync(long userId)
        {
            return await _userRepository.RoleCheckAsync(userId);
        }

        public async Task AddRoleAsync(long userId, string role)
        {
            await _userRepository.AddRoleAsync(userId, role);
        }

        public async Task<bool> UpdateAsync(ApplicationUser user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task RemoveAsync(ApplicationUser user)
        {
            await _userRepository.RemoveAsync(user);
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync(UsersFilter usersFilter)
        {            
            return await _userRepository.GetUsersAsync(usersFilter);
        }

        public async Task BlockAndUnblockUser(string userId)
        {
            var user = await _userRepository.GetAsync(userId);
            //check for null
            user.LockoutEnabled = !user.LockoutEnabled;
            await _userRepository.UpdateAsync(user);
            //return result
        }
    }
}
