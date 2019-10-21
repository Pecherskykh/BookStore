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
        public async Task<TokenModel> GenerateToken(ApplicationUser user, string roleName)
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


            var tokenAccess = new JwtSecurityToken(
            issuer: AuthOptions._issuer,
            audience: AuthOptions._audience,
            claims: claimsAccess,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var tokenRefresh = new JwtSecurityToken(
            issuer: AuthOptions._issuer,
            audience: AuthOptions._audience,
            claims: claimsRefresh,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new TokenModel
            {
                TokenAccess = new JwtSecurityTokenHandler().WriteToken(tokenAccess),
                TokenRefresh = new JwtSecurityTokenHandler().WriteToken(tokenRefresh)
            };
        }
    }
}
