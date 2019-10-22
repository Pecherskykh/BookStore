using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Book_Store.Helper.Interface
{
    public interface IJwtHelper
    {
        Task<TokenModel> GenerateTokenModel(ApplicationUser user, string roleName);
    }
}
