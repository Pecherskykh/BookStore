using BookStore.BusinessLogic.Models.Base;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Models.OrdersFilterModel
{
    public class OrdersFilterModel : BaseFilterModel
    {
        public OrderSortType SortType { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
