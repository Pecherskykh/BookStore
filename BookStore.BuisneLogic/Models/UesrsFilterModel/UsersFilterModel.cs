using BookStore.BusinessLogic.Models.Base;
using static BookStore.DataAccess.Models.Enums.Enums.UserFilterEnums;

namespace BookStore.BusinessLogic.Models.UesrsFilterModel
{
    public class UsersFilterModel : BaseFilterModel
    {
        public SortType SortType { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}