using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Helpers;
using BookStore.BusinessLogic.Services;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.EFRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountServise _accountService;

        public AccountController(UserManager<ApplicationUser> userManager, IAccountServise accountService)
        {
            _userManager = userManager;
            _accountService = accountService;
        }

        public async Task<IActionResult> Register()
        {
            var user = new ApplicationUser { UserName = "Name", Email = "oleksandr.pecherskikh@gmail.com" };
            var result = _userManager.CreateAsync(user).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);                
                EmailHelper h = new EmailHelper();
                h.Send(string.Format("Confirm the registration by clicking on the link: <a href='https://localhost:44360/api/account/confirmEmail?userId={0}&token={1}'>link</a>", user.Id, code));
            }
            return Ok();
        }

        [HttpPost("testPost")]
        public async Task<IActionResult> TestPost([FromBody] TestPostModel model)
        {
            return Ok(model.TestString);
        }

        [HttpGet("testGet")]
        public async Task<IActionResult> TestGet()
        {
            return Ok("get");
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return Ok("User not found");
            }
            try {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Ok("User not found");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token.Replace(" ", "+"));
            }
            catch (Exception ex) {
                ;
            }
            return Ok();
        }

        public async Task<IActionResult> ForgotPassword()
        {
            var user = _userManager.FindByEmailAsync("oleksandr.pecherskikh@gmail.com").GetAwaiter().GetResult();

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            EmailHelper h = new EmailHelper();
            h.Send(string.Format("Reset password: <a href='https://localhost:44360/api/account/resetPassword?userId={0}&token={1}&password={2}'>link</a>", user.Id, code, "0000"));
            return Ok();
        }

        [HttpGet("resetPassword")]
        public async Task<IActionResult> ResetPassword(string userId, string token, string password)
        {
            var t = token.Replace(" ", "+");
            var user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            var result = await _userManager.ResetPasswordAsync(user, t, password);
            return Ok();
        }
    }

    public class TestPostModel
    {
        public string TestString { get; set; }
    }
}