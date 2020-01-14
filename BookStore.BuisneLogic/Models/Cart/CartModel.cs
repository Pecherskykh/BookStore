using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.OrderItems;

namespace BookStore.BusinessLogic.Models.Cart
{
    public class CartModel : BaseFilterModel
    {
        public OrderItemModel OrderItemModel { get; set; }
        public decimal OrderAmount { get; set; }
        public string TransactionId { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
    }
}
