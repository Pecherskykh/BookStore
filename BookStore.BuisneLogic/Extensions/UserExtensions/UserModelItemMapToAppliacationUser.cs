using BookStore.BusinessLogic.Models.Users;
using BookStore.DataAccess.Entities;

namespace BookStore.BusinessLogic.Extensions.UserExtensions
{
    public static class UserModelItemMapToAppliacationUser
    {
        public static ApplicationUser Map(this UserModelItem user)
        {
            return new ApplicationUser()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName
            };
        }
    }
}