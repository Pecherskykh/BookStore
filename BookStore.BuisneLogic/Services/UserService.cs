using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions.UserExtensions;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.UesrsFilterModel;
using BookStore.BusinessLogic.Models.Users;
using BookStore.BusinessLogic.Extensions.UesrsFilterExtensions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using static BookStore.DataAccess.Entities.Enums.Enums.RoleEnums;

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
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return resultModel;
            }
            var result = await _userRepository.CreateAsync(user.Map());
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotCreatedError);
            }
            return resultModel;
        }

        public async Task<UserModelItem> FindByIdAsync(string userId) //todo do you need this method?
        {
            var resultModel = new UserModelItem();
            if (string.IsNullOrWhiteSpace(userId))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserIdIsEmptyError);
                return resultModel;
            }
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return user.Map();
        }

        public async Task<BaseModel> UpdateAsync(UserModelItem user, string role)
        {
            var resultModel = new BaseModel();
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return resultModel;
            }
            var applicationUser = await _userRepository.FindByIdAsync(user.Id.ToString());
            if (applicationUser == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            if (string.Equals(role, RoleEnum.Admin.ToString()))
            {
                applicationUser.FirstName = user.FirstName;
                applicationUser.LastName = user.LastName;                
            }
            if (string.Equals(role, RoleEnum.User.ToString()))
            {
                applicationUser.FirstName = user.FirstName;
                applicationUser.LastName = user.LastName;
                applicationUser.Email = user.Email;
                applicationUser.PasswordHash = user.Password;
            }
            var result = await _userRepository.UpdateAsync(applicationUser);
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.DataNotUpdatedError);
                return resultModel;
            }
            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(UserModelItem user)
        {
            var resultModel = new BaseModel();
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return resultModel;
            }
            var result = await _userRepository.RemoveAsync(user.Map());
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.DataNotRemovedError);
                return resultModel;
            }
            return resultModel;
        }

        public async Task<UserModel> GetUsersAsync(UsersFilterModel usersFilter)
        {
            var resultModel = new UserModel();
            if (usersFilter == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UsersFilterModelIsEmptyError);
                return resultModel;
            }
            var users = await _userRepository.GetUsersAsync(usersFilter.Map());            
            foreach(var user in users)
            {
                resultModel.Items.Add(user.Map());
            }
            return resultModel;
        }

        public async Task<BaseModel> ChangeUserStatus(string userId)
        {
            var resultModel = new BaseModel();
            if (string.IsNullOrWhiteSpace(userId))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserIdIsEmptyError);
                return resultModel;
            }
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
