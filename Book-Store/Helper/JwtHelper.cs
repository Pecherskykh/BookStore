using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Users;
using BookStore.Presentation.Helper.Interface;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.BusinessLogic.Models.Token;

namespace BookStore.Presentation.Helper
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IAccountServise _accountService;

        public JwtHelper(IAccountServise accountService)
        {
            _accountService = accountService;
        }

        public async Task<TokenModel> GenerateTokenModel(UserModelItem user)
        {
            //1.CheckPasswordSignInAsync
            //2.SignInAsync
            //3.Generate tokens
            if (user == null)
            {
                return null;
            }

            var result = await _accountService.CheckUserAsync(user);

            /*if (!result)
            {
                return null;
            }*/
            
            var claimsAccess = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name, user.UserName),
                };

            var claimsRefresh = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

            var accessToken = GenerateToken(claimsAccess, 1);
            var refreshToken = GenerateToken(claimsRefresh, 60); //todo add const

            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
            };
        }

        private JwtSecurityToken GenerateToken(List<Claim> claims, long expires)
        {
            var token = new JwtSecurityToken(
            issuer: AuthOptions._issuer,
            audience: AuthOptions._audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expires),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return token;
        }

        public bool CheckToken(string token)
        {
            var expires = new JwtSecurityTokenHandler().ReadToken(token).ValidTo;            
            return expires >= DateTime.Now;
        }
    }
}
