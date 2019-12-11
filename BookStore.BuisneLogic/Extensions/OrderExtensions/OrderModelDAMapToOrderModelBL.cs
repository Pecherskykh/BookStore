using BookStore.BusinessLogic.Models.Orders;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Extensions.OrderExtensions
{
    public static class OrderModelDAMapToOrderModelBL
    {
        public static OrderModel Map(this DataAccess.Models.Orders.OrderModel orderModel)
        {
            var items = new List<OrderModelItem>();
            foreach (DataAccess.Models.Orders.OrderModelItem orderModelItem in orderModel.Items)
            {
                items.Add(orderModelItem.Map());
            }

            return new OrderModel
            {
                Count = orderModel.Count,
                Items = items
            };
        }
    }
}
