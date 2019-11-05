using BookStore.BusinessLogic.Models.OrderItems;
using BookStore.DataAccess.Models.Base;

namespace BookStore.BusinessLogic.Models.Cart
{
    public class CartModel : BaseFilterModel
    {
        public OrderItemModel OrderItemModel { get; set; }
        public long TransactionId { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
    }
}
