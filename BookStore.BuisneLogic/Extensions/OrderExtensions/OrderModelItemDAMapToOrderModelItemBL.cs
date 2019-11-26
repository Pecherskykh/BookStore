using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Extensions.OrderItemExtensions;

namespace BookStore.BusinessLogic.Extensions.OrderExtensions
{
    public static class OrderModelItemDAMapToOrderModelItemBL
    {
        public static OrderModelItem Map(this BookStore.DataAccess.Models.Orders.OrderModelItem order)
        {
            return new OrderModelItem()
            {
                Id = order.Id,
                Date = order.Date,
                UserName = order.UserName,
                UserEmail = order.UserEmail,
                OrderItems = order.OrderItems.Map(),                
                OrderAmount = order.OrderAmount
            };
        }
    }
}
