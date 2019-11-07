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
                UserStatus = (DataAccess.Models.Enums.Enums.UserStatus)usersFilterModel.UserStatus,
                SearchString = usersFilterModel.SearchString,
                SortType = (DataAccess.Models.Enums.Enums.UserSortType)usersFilterModel.SortType,
                SortingDirection = (DataAccess.Models.Enums.Enums.SortingDirection)usersFilterModel.SortingDirection                
            };
        }
    }
}