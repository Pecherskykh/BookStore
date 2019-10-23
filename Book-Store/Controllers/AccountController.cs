using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.Helper.Interface;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServise _accountService;
        private readonly IJwtHelper _jwtHelper;

        public AccountController(IAccountServise accountService, IJwtHelper jwtHelper)
        {
            _accountService = accountService;
            _jwtHelper = jwtHelper;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _accountService.GetNameAsync(userName);
            if(user == null)
            {
                return Ok();
            }
            if(!await _accountService.CheckUserAsync(user, password, false))
            {
                return Ok();
            }
            var role = await _accountService.RoleCheckAsync(user.Id);
            if (role == null)
            {
                return Ok();
            }

            var encodedJwt = await _jwtHelper.GenerateTokenModel(user, role.Name);

            HttpContext.Response.Cookies.Append("accessToken", encodedJwt.AccessToken);
            HttpContext.Response.Cookies.Append("refreshToken", encodedJwt.RefreshToken);
            //return Ok(new BaseModel());
            return Ok();
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            await _accountService.Register();
            //return Ok(new BaseModel());
            return Ok();
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            await _accountService.ConfirmEmail(userId, token);
            return Ok();
        }

        [HttpGet("forgotPassword")]
        public async Task<IActionResult> ForgotPassword()
        {
            await _accountService.ForgotPassword();
            return Ok();
        }
        
        [HttpGet("resetPassword")]
        public async Task<IActionResult> ResetPassword(string userId, string token, string password)
        {
            await _accountService.ResetPassword(userId, token, password);
            return Ok();
        }

        //public async Task<IActionResult> CheckJwtToken(string accessToken, string refreshToken)
        //{
        //    var expiresAccess = new JwtSecurityTokenHandler().ReadToken(accessToken).ValidTo;

        //    if (expiresAccess < DateTime.Now)
        //    {
        //        await RefreshToken(refreshToken);
        //    }
        //    return Ok();
        //}

        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var expires = new JwtSecurityTokenHandler().ReadToken(refreshToken).ValidTo; //check token from jwtHelper

            if (expires >= DateTime.Now)
            {
                var userId = this.HttpContext.User.Claims
               .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var user = await _accountService.GetAsync(userId);
                var role = await _accountService.RoleCheckAsync(user.Id);
                var encodedJwt = await _jwtHelper.GenerateTokenModel (user, role.Name);
            }
            return Ok();
        }   
    }
}