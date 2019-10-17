using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BookStore.DataAccess.Repositories.EFRepositories;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.BusinessLogic.Helpers;
using BookStore.DataAccess.Entities;
//using Book_Store.Helper;

namespace BookStore.BusinessLogic.Services
{
    public class AccountService : IAccountServise
    {
        private readonly IUserRepository _userRepository;

        public object JwtHelper { get; private set; }

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> GetAsync(string userId)
        {
            return await _userRepository.GetAsync(userId);
        }

        public async Task<ApplicationUser> GetEmailAsync(string email)
        {
            return await _userRepository.GetEmailAsync(email);
        }

        public async Task<ApplicationUser> GetUserNameAndPassword(string userName, string password)
        {
            return await _userRepository.GetUserNameAndPassword(userName, password);
        }

        public async Task<bool> CreateAsync(ApplicationUser user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<Role> RoleCheckAsync(long userId)
        {
            return await _userRepository.RoleCheckAsync(userId);
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
            var user = new ApplicationUser { UserName = "Name", Email = "oleksandr.pecherskikh@gmail.com" };
            var result = await CreateAsync(user);
            if (result)
            {
                string code = await _userRepository.UserManager.GenerateEmailConfirmationTokenAsync(user);
                EmailHelper h = new EmailHelper();
                h.Send(string.Format("Confirm the registration by clicking on the link: <a href='http://localhost:52976/api/account/confirmEmail?userId={0}&token={1}'>link</a>", user.Id, code));
            }
        }

        public async Task ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return;
            }
            var user = await GetAsync(userId);
            if (user == null)
            {
                return;
            }
            var result = await _userRepository.UserManager.ConfirmEmailAsync(user, token.Replace(" ", "+"));
        }

        public async Task ForgotPassword()
        {
            ApplicationUser user = await GetEmailAsync("oleksandr.pecherskikh@gmail.com");

            var code = await _userRepository.UserManager.GeneratePasswordResetTokenAsync(user);
            EmailHelper h = new EmailHelper();
            h.Send(string.Format("Reset password: <a href='http://localhost:52976/api/account/resetPassword?userId={0}&token={1}&password={2}'>link</a>", user.Id, code, "aQwery01"));
        }

        public async Task ResetPassword(string userId, string token, string password)
        {
            var user = await GetAsync(userId);
            var result = await _userRepository.UserManager.ResetPasswordAsync(user, token.Replace(" ", "+"), password);
        }
    }
}
