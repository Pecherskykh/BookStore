using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Users;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.UesrsFilterModel;
using BookStore.DataAccess.Repositories.Interfaces;
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

        public async Task<BaseModel> CreateAsync(UserModelItem user)
        {
            var resultModel = new BaseModel();
            var result = await _userRepository.CreateAsync(user.Mapping());
            if (!result)
            {
                resultModel.Errors.Add("some error"); //from consts
            }
            return resultModel;
        }

        public async Task<UserModelItem> FindByIdAsync(string userId) //todo do you need this method?
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return user.Mapping();
        }

        public async Task<bool> UpdateAsync(UserModelItem user)
        {
            return await _userRepository.UpdateAsync(user.Mapping());
        }

        public async Task<bool> RemoveAsync(UserModelItem user)
        {
            user.IsRemoved = true;
            return await _userRepository.UpdateAsync(user.Mapping());
        }

        public async Task<UserModel> GetUsersAsync(UsersFilterModel usersFilter)
        {            
            var users = await _userRepository.GetUsersAsync(usersFilter);
            var resultModel = new UserModel();
            foreach(var user in users)
            {
                resultModel.Items.Add(user.Mapping());
            }
            return resultModel;
        }

        public async Task<BaseModel> ChangeUserStatus(string userId)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByIdAsync(userId);
            if(user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            user.LockoutEnabled = !user.LockoutEnabled;
            await _userRepository.UpdateAsync(user);
            return resultModel;
        }
    }
}
