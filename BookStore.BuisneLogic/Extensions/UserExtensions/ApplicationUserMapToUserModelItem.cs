using BookStore.BusinessLogic.Models.Users;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.UserExtensions
{
    public static class ApplicationUserMapToUserModelItem
    {
        public static UserModelItem Map(this ApplicationUser user)
        {
            return new UserModelItem()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Status = user.LockoutEnabled
            };
        }
    }
}
