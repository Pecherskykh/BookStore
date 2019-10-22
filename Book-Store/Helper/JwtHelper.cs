using Book_Store.Helper.Interface;
using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Helper
{
    public class JwtHelper : IJwtHelper
    {
        public async Task<TokenModel> GenerateTokenModel(ApplicationUser user, string roleName)
        {
            var claimsAccess = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, roleName),
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
