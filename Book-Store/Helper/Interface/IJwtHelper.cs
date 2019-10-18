using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Helper.Interface
{
    public interface IJwtHelper
    {
        Task<TokenModel> GenerateToken(ApplicationUser user, string roleName);
    }
}
