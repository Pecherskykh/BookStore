using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Users;
using BookStore.Presentation.Helper.Interface;

namespace BookStore.Presentation.Helper
{
    public class JwtHelper : IJwtHelper
    {
        public async Task<TokenModel> GenerateTokenModel(UserModelItem user)
        {
            if (user == null)
            {
                return null;
            }

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

            var accessToken = await GenerateToken(claimsAccess, 1);
            var refreshToken = await GenerateToken(claimsRefresh, 60);

            return new TokenModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken)
            };
        }

        private async Task<JwtSecurityToken> GenerateToken(List<Claim> claims, long expires)
        {
            var token = new JwtSecurityToken(
            issuer: AuthOptions._issuer,
            audience: AuthOptions._audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expires),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return token;
        }
    }
}
