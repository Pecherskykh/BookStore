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
using BookStore.BusinessLogic.Models.Login;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    //[AllowAnonymous]
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
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var resultModel = new UserModelItem();

            if (loginModel == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return Ok(resultModel);
            }
            resultModel = await _accountService.CheckUserAsync(loginModel);

            if(resultModel.Errors.Count != 0)
            {
                return Ok(resultModel);
            }

            var encodedJwt = _jwtHelper.GenerateTokenModel(resultModel);

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
        
        //[Authorize]
        [HttpGet("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            //oleksandr.pecherskikh@gmail.com
            var result = await _accountService.ForgotPassword(email);
            return Ok(result);
        }

        [HttpGet("refreshTokens")]
        public async Task<IActionResult> RefreshTokens(string refreshToken)
        {
            var resultModel = new BaseModel();

            if (!_jwtHelper.CheckToken(refreshToken))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.RefreshTokenIsNotValidError);
                return Ok(resultModel);
            }

            var userId = new JwtSecurityTokenHandler().ReadJwtToken(refreshToken).Claims.Where(x => x.Type.Contains("nameidentifier")).FirstOrDefault().Value;

            var user = await _accountService.FindByIdAsync(userId);

            var encodedJwt = _jwtHelper.GenerateTokenModel(user);

            HttpContext.Response.Cookies.Append("accessToken", encodedJwt.AccessToken); //todo replace to private method
            HttpContext.Response.Cookies.Append("refreshToken", encodedJwt.RefreshToken);

            return Ok(resultModel);
        }

        [Authorize]
        [HttpGet("logOut")]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.LogOutAsync();
            return Ok();
        }
    }
}