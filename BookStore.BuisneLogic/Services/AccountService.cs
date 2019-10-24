using System.Threading.Tasks;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.BusinessLogic.Helpers.Interfaces;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Common.Constants;
using static BookStore.BusinessLogic.Common.Constants.Constants;
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
            //var result = new UserModelItem();
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                //result.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
            }
            //return result
            //map entity to model
            return user.Mapping();
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            var user = await _userRepository.FindByNameAsync(userName);
            if (user == null)
            {
                //return errors
            }
            /*var result = await CheckUserAsync(user, "pass");
            if (!result)
            {
                //resturn errors
            }
            var role = await RoleCheckAsync(user.Id);
            //userModel.Role = role;
            //return userModel;*/
            return user;
        }

        public async Task<bool> CreateAsync(ApplicationUser user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<Role> CheckRoleAsync(long userId)
        {
            return await _userRepository.CheckRoleAsync(userId);
        }

        public async Task AddRoleAsync(long userId, string role)
        {
            await _userRepository.AddRoleAsync(userId, role);
        }

        public async Task RemoveAsync(ApplicationUser user)
        {
            await _userRepository.RemoveAsync(user);
        }

        public async Task Register()
        {
            var user = new ApplicationUser
            { 
                UserName = "Name",
                Email = "oleksandr.pecherskikh@gmail.com"
            };
            var result = await CreateAsync(user);
            if (result)
            {
                //string code = await _userRepository.UserManager.GenerateEmailConfirmationTokenAsync(user);
                //_emailHelper.Send(string.Format("Confirm the registration by clicking on the link: <a href='http://localhost:52976/api/account/confirmEmail?userId={0}&token={1}'>link</a>", user.Id, code));
            }
        }

        public async Task ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null) //use string.IsNullOrWhileSpace(...)
            {
                return;
            }
            var user = await FindByIdAsync(userId);
            if (user == null)
            {
                return;
            }
            //var result = await _userRepository.UserManager.ConfirmEmailAsync(user, token.Replace(" ", "+"));
        }

        public async Task ForgotPassword()
        {
            var user = await FindByEmailAsync("oleksandr.pecherskikh@gmail.com"); //remove hardcode
            //if (user == null)

            //var code = await _userRepository.UserManager.GeneratePasswordResetTokenAsync(user);
            //send new password for email
            //_emailHelper.Send(string.Format("Reset password: <a href='http://localhost:52976/api/account/resetPassword?userId={0}&token={1}&password={2}'>link</a>", user.Id, code, "aQwery01_77775"));
        }

        public async Task ResetPassword(string userId, string token, string password)
        {
            var user = await FindByIdAsync(userId);
            //var result = await _userRepository.UserManager.ResetPasswordAsync(user, token.Replace(" ", "+"), password);
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
