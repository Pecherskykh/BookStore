using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Users;
using BookStore.Presentation.Helper.Interface;
using BookStore.BusinessLogic.Models.Token;
using BookStore.BusinessLogic.Common.Constants;

namespace BookStore.Presentation.Helper
{
    public class JwtHelper : IJwtHelper
    {
        public TokenModel GenerateTokenModel(UserModelItem user)
        {            
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

            var accessToken = GenerateToken(claimsAccess, Constants.JwtConstants.ExpiresAccessToken);
            var refreshToken = GenerateToken(claimsRefresh, Constants.JwtConstants.ExpiresRefreshToken); //todo add const

            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
            };
        }

        private JwtSecurityToken GenerateToken(List<Claim> claims, decimal expires)
        {
            var token = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes((double)expires),
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
