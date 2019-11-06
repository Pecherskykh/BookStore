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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModelItem user) //todo add model to Login UserModelItem
        {
            var resultModel = new BaseModel();

            if (user == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserModelItemIsEmptyError);
                return Ok(resultModel);
            }

            var encodedJwt = await _jwtHelper.GenerateTokenModel(user);

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
            /*var user = new UserModelItem
            {
                UserName = "Name",
                Email = "oleksandr.pecherskikh@gmail.com",
                Password = "HardCodePasswor@0001"
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
        [HttpPost("forgotPassword")]
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
                return Ok(resultModel);
            }
            var userId = this.HttpContext.User.Claims
               .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = await _accountService.FindByNameAsync(userId);
            var encodedJwt = await _jwtHelper.GenerateTokenModel(user);
            HttpContext.Response.Cookies.Append("accessToken", encodedJwt.AccessToken);
            HttpContext.Response.Cookies.Append("refreshToken", encodedJwt.RefreshToken);

            return Ok(resultModel); //todo add error if expire
        }   
    }
}