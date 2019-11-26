using BookStore.BusinessLogic.Models.Orders;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.OrderExtensions
{
    public static class OrderModelItemMapToOrder
    {
        public static Order Map(this OrderModelItem order)
        {
            return new Order()
            {
                Id = order.Id,
                IsRemoved = order.IsRemoved,
                PaymentId = order.PaymentId,
                UserId = order.UserId
            };
        }
    }
}
