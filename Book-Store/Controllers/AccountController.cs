using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Book_Store.Helper;
using Book_Store.Helper.Interface;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IJwtHelper _jwt;

        public AccountController(IAccountServise accountService, IJwtHelper jwt)
        {
            _accountService = accountService;
            _jwt = jwt;
        }

        [HttpGet("token")]
        public async Task<IActionResult> Token(string userName, string password)
        {
            //1.Check user in DB with UserManager
            //2.CheckPasswordSignInAsync
            //3.SignInAsync
            //4.Generate tokens


            userName = "Name";
            password = "aQwery01_77775";
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
            var encodedJwt = await _jwt.GenerateToken(user, role.Name);
            /*var response = new
            {
                access_token = encodedJwt,
                userName = userName
            };
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));*/
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

        [Authorize]
        [HttpGet("auto")]
        public async Task<IActionResult> Auto()
        {            
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