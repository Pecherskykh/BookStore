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
    public class JwtHelper
    {
        private readonly ApplicationContext _applicationContext;

        public JwtHelper(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [HttpPost("/token")]
        public string Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return null;
            }

            var token = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: identity,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> GetIdentity(string username, string password)
        {
            ApplicationUser user = _applicationContext.Users.FirstOrDefault(u => u.UserName == username && u.PasswordHash == password);
            long roleId = _applicationContext.UserRoles.FirstOrDefault(obj => obj.UserId == user.Id).RoleId;
            Role role = _applicationContext.Roles.FirstOrDefault(r => r.Id == roleId);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name)
                };
                return claims;
            }
            return null;
        }
    }
}
