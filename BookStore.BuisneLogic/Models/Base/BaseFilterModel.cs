using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Models.Base
{
    public class BaseFilterModel
    {
        public SortingDirection SortingDirection { get; set; }
        public string SearchString { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
