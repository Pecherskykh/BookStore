using System.Threading.Tasks;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.BusinessLogic.Helpers.Interfaces;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Common.Constants;
using static BookStore.BusinessLogic.Common.Constants.EmailConstants;
using BookStore.BusinessLogic.Common;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Users;

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

        public async Task<BaseModel> CreateAsync(ApplicationUser user)
        {
            var resultModel = new BaseModel();
            var result = await _userRepository.CreateAsync(user);
            if (!result)
            {
                resultModel.Errors.Add("some error"); //from consts
            }
            return resultModel;
        }

        private async Task<Role> CheckRoleAsync(long userId)
        {
            return await _userRepository.CheckRoleAsync(userId);
        }

        /*public async Task AddRoleAsync(long userId, string role)
        {
            await _userRepository.AddRoleAsync(userId, role);
        }*/

        public async Task RemoveAsync(ApplicationUser user)
        {
            await _userRepository.RemoveAsync(user);
        }

        public async Task<BaseModel> Register()
        {
            var resultModel = new BaseModel();
            var user = new ApplicationUser
            { 
                UserName = "Name",
                Email = "oleksandr.pecherskikh@gmail.com"
            };
            var result = await _userRepository.CreateAsync(user);
            if (!result)
            {
                resultModel.Errors.Add("Const");
                return resultModel;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(user);
            _emailHelper.Send(string.Format("Confirm the registration by clicking on the link: <a href='http://localhost:52976/api/account/confirmEmail?userId={0}&token={1}'>link</a>", user.Id, token));
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
            await _userRepository.ResetPasswordAsync(user, token, "aQwery01_77775");
            //send new password for email
            _emailHelper.Send(string.Format("New password: {0}", "aQwery01_77775"));
            return resultModel;
        }

        public async Task<bool> CheckUserAsync(ApplicationUser user, string password, bool lockoutOnFailure)
        {
            return await _userRepository.CheckUserAsync(user, password, lockoutOnFailure);
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            await _userRepository.SignInAsync(user, isPersistent);
        }
    }
}
