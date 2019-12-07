using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.BusinessLogic.Helpers.Interfaces;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Models.Users;
using BookStore.BusinessLogic.Extensions.UserExtensions;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Login;

namespace BookStore.BusinessLogic.Services
{
    public class AccountService : IAccountServise
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailHelper _emailHelper;
        private readonly ICreatePasswordHelper _createPasswordHelper;

        public AccountService(IUserRepository userRepository, IEmailHelper emailHelper, ICreatePasswordHelper createPasswordHelper)
        {
            _userRepository = userRepository;
            _emailHelper = emailHelper;
            _createPasswordHelper = createPasswordHelper;
        }

        public async Task<UserModelItem> FindByIdAsync(string userId)
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

        public async Task<UserModelItem> FindByEmailAsync(string email)
        {
            var resultModel = new UserModelItem();
            if (string.IsNullOrWhiteSpace(email))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserEmailIsEmptyError);
                return resultModel;
            }
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return user.Map();
        }

        public async Task<UserModelItem> FindByNameAsync(string userName)
        {
            var resultModel = new UserModelItem();
            if (string.IsNullOrWhiteSpace(userName))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNameIsEmptyError);
                return resultModel;
            }
            var user = await _userRepository.FindByNameAsync(userName);
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            resultModel.Role = await _userRepository.CheckRoleAsync(user.Id.ToString());
            return user.Map();
        }

        public async Task<BaseModel> Register(UserModelItem user)
        {
            var resultModel = new BaseModel();
            if(user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return resultModel;
            }

            var applicationUser = user.Map();

            var result = await _userRepository.CreateAsync(applicationUser);
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotCreatedError);
                return resultModel;
            }
            string token = await _userRepository.GenerateEmailConfirmationTokenAsync(applicationUser);
            if(string.IsNullOrWhiteSpace(token))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.EmailConfirmationTokenNotGeneratedError);
                return resultModel;
            }
            await _emailHelper.Send(user.Email, 
                string.Format("Confirm the registration by clicking on the link: <a href='" +
                Constants.EmailConstants.ConfirmEmail + "'>link</a>", applicationUser.Id, token));
            return resultModel;
        }

        public async Task<BaseModel> ConfirmEmail(string userId, string token)
        {
            var resultModel = new BaseModel();
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.TokenOrUserIdIsEmptyError);
                return resultModel;
            }
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            var result = await _userRepository.ConfirmEmailAsync(user, token.CheckGap());
            if(!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.EmailNotConfirmedError);
                return resultModel;
            }
            return resultModel;
        }

        public async Task<BaseModel> ForgotPassword(string userEmail)
        {
            var resultModel = new BaseModel();
            if(string.IsNullOrWhiteSpace(userEmail))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserEmailIsEmptyError);
                return resultModel;
            }
            var user = await _userRepository.FindByEmailAsync(userEmail);
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            var token = await _userRepository.GeneratePasswordResetTokenAsync(user);
            if (string.IsNullOrWhiteSpace(token))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PasswordResetTokenNotGeneratedError);
                return resultModel;
            }
            var password = _createPasswordHelper.CreatePassword(8);
            var result = await _userRepository.ResetPasswordAsync(user, token, password);
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PasswordNotChangedError);
                return resultModel;
            }
            await _emailHelper.Send(userEmail, string.Format("New password: {0}", password));
            return resultModel;
        }

        public async Task<UserModelItem> CheckUserAsync(LoginModel loginModel) //todo LoginAsync or SignInAsync
        {
            var resultModel = new UserModelItem();
            if (loginModel == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return resultModel;
            }
            var applicationUser = await _userRepository.FindByEmailAsync(loginModel.Email);
            if (applicationUser == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            var result = await _userRepository.CheckUserAsync(applicationUser, loginModel.Password);
            if(!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            resultModel = applicationUser.Map();
            resultModel.Role = await _userRepository.CheckRoleAsync(applicationUser.Id.ToString());
            return resultModel;
        }

        public async Task<string> CheckRoleAsync(UserModelItem user) //todo add role directly
        {
            string result = null;
            if (user == null)
            {
                return result;
            }
            var applicationUser = await _userRepository.FindByNameAsync(user.UserName);
            if (applicationUser == null)
            {
                return result;
            }
            result = await _userRepository.CheckRoleAsync(applicationUser.Id.ToString());
            return result;
        }

        public async Task LogOutAsync()
        {
            await _userRepository.LogOutAsync();
        }
    }
}
