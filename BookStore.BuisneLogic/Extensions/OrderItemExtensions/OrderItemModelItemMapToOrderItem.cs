using BookStore.BusinessLogic.Models.OrderItems;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.OrderItemExtensions
{
    public static class OrderItemModelItemMapToOrderItem
    {
        public static OrderItem Map(this OrderItemModelItem orderItem)
        {
            return new OrderItem()
            {
                Amount = orderItem.Amount,
                Currency = orderItem.Currency,
                Count = orderItem.Count,
                OrderId = orderItem.OrderId,
                PrintingEditionId = orderItem.PrintingEditionId
            };
        }
    }
}
