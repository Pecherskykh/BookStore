using BookStore.DataAccess.Models.Base;
using static BookStore.DataAccess.Models.Enums.Enums.OrdersFilterEnums;

namespace BookStore.BusinessLogic.Models.OrdersFilterModel
{
    public class OrdersFilterModel : BaseFilterModel
    {
        public SortType SortType { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
