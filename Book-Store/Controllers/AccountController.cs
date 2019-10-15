using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Helpers;
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

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //return View();
            return Ok();
        }

        public void Register()
        {
            var user = new ApplicationUser { UserName = "Name", Email = "oleksandr.pecherskikh@gmail.com" };
            var result = _userManager.CreateAsync(user).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(user).GetAwaiter().GetResult();
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new {userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                EmailHelper h = new EmailHelper();
                h.Send(string.Format("Подтвердите регистрацию, перейдя по ссылке: <a href='https://localhost:44360/api/account/confirmEmail?userId={0}&token={1}'>link</a>", user.Id, code));
            }
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
        //https://localhost:44360/api/account/confirmEmail?userId=id&token=token

            return Ok();
        }
    }
}