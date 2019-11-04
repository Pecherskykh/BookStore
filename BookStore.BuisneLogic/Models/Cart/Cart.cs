using BookStore.BusinessLogic.Models.OrderItems;
using BookStore.DataAccess.Models.Base;

namespace BookStore.BusinessLogic.Models.Cart
{
    public class Cart : BaseModel //todo renema to CartModel
    {
        public OrderItemModel OrderItemModel { get; set; }
        public long TransactionId { get; set; }
        public string Description { get; set; }
        public long userId { get; set; } //todo rename to UserId
    }
}
