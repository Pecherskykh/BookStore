using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Users;
using BookStore.Presentation.Helper.Interface;
using BookStore.BusinessLogic.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [AllowAnonymous]
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModelItem user)
        {
            var resultModel = new BaseModel();
            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return Ok(resultModel);
            }

            var encodedJwt = _jwtHelper.GenerateTokenModel(user);

            if (encodedJwt != null)
            {
                HttpContext.Response.Cookies.Append("accessToken", encodedJwt.AccessToken);
                HttpContext.Response.Cookies.Append("refreshToken", encodedJwt.RefreshToken);
            }
            return Ok(resultModel);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModelItem user)
        {
            var result = await _accountService.Register(user);
            return Ok(result);
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _accountService.ConfirmEmail(userId, token);
            return Ok(result);
        }
        
        [Authorize]
        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            //oleksandr.pecherskikh@gmail.com
            var result = await _accountService.ForgotPassword(email);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("refreshTokens")]
        public async Task<IActionResult> RefreshTokens(string refreshToken)
        {
            var resultModel = new BaseModel();
            if (!_jwtHelper.CheckToken(refreshToken))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.RefreshTokenIsNotValidError); //todo const
                return Ok(resultModel);
            }
            var userId = this.HttpContext.User.Claims
               .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = await _accountService.FindByNameAsync(userId);
            var encodedJwt = _jwtHelper.GenerateTokenModel(user);
            HttpContext.Response.Cookies.Append("accessToken", encodedJwt.AccessToken);
            HttpContext.Response.Cookies.Append("refreshToken", encodedJwt.RefreshToken);

            return Ok(resultModel);
        }

        //todo add logout
        [Authorize]
        [HttpPost("logOut")]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.LogOutAsync();
            return Ok();
        }
    }
}