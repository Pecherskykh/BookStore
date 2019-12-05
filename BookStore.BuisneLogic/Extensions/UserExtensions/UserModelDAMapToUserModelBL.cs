using BookStore.BusinessLogic.Models.Users;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Extensions.UserExtensions
{
    public static class UserModelDAMapToUserModelBL
    {
        public static UserModel Map(this DataAccess.Models.Users.UserModel userModel)
        {
            var items = new List<UserModelItem>();

            foreach(var item in userModel.Items)
            {
                items.Add(item.Map());
            }

            return new UserModel()
            {
                Count = userModel.Count,
                Items =  items
            };
        }
    }
}
