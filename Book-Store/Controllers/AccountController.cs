using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Book_Store.Helper;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Book_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServise _accountService;

        public AccountController(IAccountServise accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("token")]
        public async Task<IActionResult> Token(string userName, string password)
        {
            userName = "Name";
            password = "00000";
            JwtHelper jwt = new JwtHelper();
            var user = await _accountService.GetUserNameAndPassword(userName, password);
            if(user == null)
            {
                return Ok();
            }
            var role = await _accountService.RoleCheckAsync(user.Id);
            if (role == null)
            {
                return Ok();
            }
            var encodedJwt = jwt.Token(userName, role.Name);
            var response = new
            {
                access_token = encodedJwt,
                userName = userName
            };
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            return Ok();
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            await _accountService.Register();
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
    }
}