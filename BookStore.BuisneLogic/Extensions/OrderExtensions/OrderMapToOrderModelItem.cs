using BookStore.BusinessLogic.Models.Orders;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.OrderExtensions
{
    public static class OrderMapToOrderModelItem
    {
        public static OrderModelItem Map(this Order order)
        {
            return new OrderModelItem()
            {
                Id = order.Id,
                Date = order.CreationDate,
            };
        }
    }
}
