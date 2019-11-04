using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Users;
using BookStore.Presentation.Helper.Interface;

namespace BookStore.Presentation.Controllers
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
        public async Task<IActionResult> Login(string userName, string password) //todo add model to Login
        {
            var resultModel = new BaseModel();
            var user = await _accountService.FindByNameAsync(userName); //todo return BaseModel

            var encodedJwt = _jwtHelper.GenerateTokenModel(user);

            if (encodedJwt != null)
            {
                HttpContext.Response.Cookies.Append("accessToken", encodedJwt.AccessToken);
                HttpContext.Response.Cookies.Append("refreshToken", encodedJwt.RefreshToken);
            }
            return Ok(resultModel);
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register(UserModelItem user)
        {
            /*var user = new ApplicationUser
            {
                UserName = "Name",
                Email = "oleksandr.pecherskikh@gmail.com"
            };*/
            var result = await _accountService.Register(user);
            return Ok(result);
        }

        //todo add attr
        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _accountService.ConfirmEmail(userId, token);
            return Ok(result);
        }

        //todo add attr
        [HttpGet("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            //oleksandr.pecherskikh@gmail.com
            var result = await _accountService.ForgotPassword(email);
            return Ok(result);
        }
         //todo add attr
        public async Task<IActionResult> RefreshTokens(string refreshToken)
        {
            var expires = new JwtSecurityTokenHandler().ReadToken(refreshToken).ValidTo; //todo check token from jwtHelper

            if (expires >= DateTime.Now)
            {
                var userId = this.HttpContext.User.Claims
               .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var user = await _accountService.FindByNameAsync(userId);
                var encodedJwt = _jwtHelper.GenerateTokenModel(user);
                //todo add to coocies
            }
            return Ok(new BaseModel()); //todo add error if expire
        }   
    }
}