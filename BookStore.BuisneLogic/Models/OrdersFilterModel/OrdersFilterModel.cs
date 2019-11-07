using BookStore.DataAccess.Models.Base;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Models.OrdersFilterModel
{
    public class OrdersFilterModel : BaseFilterModel
    {
        public OrderSortType SortType { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
