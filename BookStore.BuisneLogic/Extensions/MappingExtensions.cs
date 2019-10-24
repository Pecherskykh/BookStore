using BookStore.BusinessLogic.Models.Users;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions
{
    public static class MappingExtensions
    {
        public static UserModelItem Mapping(this ApplicationUser user)
        {
            return new UserModelItem()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName
            };
        }
    }
}
