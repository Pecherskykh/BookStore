using BookStore.BusinessLogic.Models.UesrsFilterModel;

namespace BookStore.BusinessLogic.Extensions.UesrsFilterExtensions
{
    public static class UsersFilterModelBLMapToUsersFilterModelDA
    {
        public static DataAccess.Models.UesrsFilterModel.UsersFilterModel Map(this UsersFilterModel usersFilterModel)
        {
            return new BookStore.DataAccess.Models.UesrsFilterModel.UsersFilterModel
            {
                PageCount = usersFilterModel.PageCount,
                PageSize = usersFilterModel.PageSize,
                UserStatus = usersFilterModel.UserStatus,
                SearchString = usersFilterModel.SearchString,
                SortType = usersFilterModel.SortType,
                SortingDirection = usersFilterModel.SortingDirection                
            };
        }
    }
}