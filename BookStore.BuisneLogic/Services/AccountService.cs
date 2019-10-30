using System.Threading.Tasks;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.BusinessLogic.Helpers.Interfaces;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Users;
using BookStore.BusinessLogic.Helpers;

namespace BookStore.BusinessLogic.Services
{
    public class AccountService : IAccountServise
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailHelper _emailHelper;

        public object JwtHelper { get; private set; }

        public AccountService(IUserRepository userRepository, IEmailHelper emailHelper)
        {
            _userRepository = userRepository;
            _emailHelper = emailHelper;
        }

        public async Task<UserModelItem> FindByIdAsync(string userId)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
            }
            return user.Mapping();
        }

        public async Task<UserModelItem> FindByEmailAsync(string email)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
            }
            return user.Mapping();
        }

        public async Task<UserModelItem> FindByNameAsync(string userName)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.FindByNameAsync(userName);
            if (user == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
            }
            /*var result = await CheckUserAsync(user, "pass");
            if (!result)
            {
                //resturn errors
            }*/
            var role = await CheckRoleAsync(user.Id);
            resultModel.Role = role.Name;
            return user.Mapping();
        }


        private async Task<Role> CheckRoleAsync(long userId)
        {
            return await _userRepository.CheckRoleAsync(userId);
        }

        /*public async Task AddRoleAsync(long userId, string role)
        {
            await _userRepository.AddRoleAsync(userId, role);
        }*/

        public async Task RemoveAsync(UserModelItem user)
        {
            await _userRepository.RemoveAsync(user.Mapping());
        }

        public async Task<BaseModel> Register(UserModelItem user)
        {
            var resultModel = new BaseModel();
            var applicationUser = user.Mapping();

            var result = await _userRepository.CreateAsync(applicationUser);
            if (!result)
            {
                resultModel.Errors.Add("Const");
                return resultModel;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(applicationUser);
            await _emailHelper.Send(user.Email, string.Format("Confirm the registration by clicking on the link: <a href='http://localhost:52976/api/account/confirmEmail?userId={0}&token={1}'>link</a>", user.Id, token));
            return resultModel;
        }

        public async Task<BaseModel> ConfirmEmail(string userId, string token)
        {
            var resultModel = new BaseModel();
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) //use string.IsNullOrWhileSpace(...)
            {
                resultModel.Errors.Add("Const");
                return resultModel;
            }
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            await _userRepository.ConfirmEmailAsync(user, token.Replace(" ", "+"));
            return resultModel;
        }

        public async Task<BaseModel> ForgotPassword(string userEmail)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(userEmail); //remove hardcode
            if (user == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            var token = await _userRepository.GeneratePasswordResetTokenAsync(user);
            var password = CreatePasswordHelper.CreatePassword(8);
            await _userRepository.ResetPasswordAsync(user, token, password);
            //send new password for email
            await _emailHelper.Send(userEmail, string.Format("New password: {0}", password));
            return resultModel;
        }

        public async Task<bool> CheckUserAsync(UserModelItem user, string password, bool lockoutOnFailure)
        {
            return await _userRepository.CheckUserAsync(user.Mapping(), password, lockoutOnFailure);
        }

        public async Task SignInAsync(UserModelItem user, bool isPersistent)
        {
            await _userRepository.SignInAsync(user.Mapping(), isPersistent);
        }
    }
}
