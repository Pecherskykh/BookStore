using BookStore.BusinessLogic.Models.OrderItems;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Extensions.OrderItemExtensions
{
    public static class OrderItemModelItemDAMapToOrderItemModelItemBL
    {
        public static OrderItemModelItem Map(this DataAccess.Models.OrderItems.OrderItemModelItem orderItemModelItem)
        {
            return new OrderItemModelItem()
            {
                Count = orderItemModelItem.Count,
                Type = (TypePrintingEdition)orderItemModelItem.Type,
                Title = orderItemModelItem.Title
            };
        }
    }
}
