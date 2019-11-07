using BookStore.BusinessLogic.Models.Base;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Models.UesrsFilterModel
{
    public class UsersFilterModel : BaseFilterModel
    {
        public UserSortType SortType { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}