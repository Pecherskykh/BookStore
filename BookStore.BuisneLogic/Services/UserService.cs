using BookStore.BusinessLogic.Models.Base;
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

        public async Task<BaseModel> CreateAsync(ApplicationUser user) //return BaseModel
        {
            var resultModel = new BaseModel();
            var result = await _userRepository.CreateAsync(user);
            if (!result)
            {
                resultModel.Errors.Add("some error"); //from consts
            }
            return resultModel;
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId) //return UserModel
        {
            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<Role> CheckRoleAsync(long userId)
        {
            return await _userRepository.CheckRoleAsync(userId);
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
            var users = await _userRepository.GetUsersAsync(usersFilter);
            //var resultModel = new UserModel();  
            //foreach (...)
            //{
            //    resultModel.Items.Add(mappingModel);   //map ApplicationUsers to UserModelItems
            //}
            //return UserModel
            return null;
        }

        public async Task BlockAndUnblockUser(string userId) //rename ChangeUserStatus
        {
            var user = await _userRepository.FindByIdAsync(userId);
            //check for null
            user.LockoutEnabled = !user.LockoutEnabled;
            await _userRepository.UpdateAsync(user);
            //return result
        }
    }
}
