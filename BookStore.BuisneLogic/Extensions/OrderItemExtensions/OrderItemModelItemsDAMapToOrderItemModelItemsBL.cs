using BookStore.BusinessLogic.Models.OrderItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.OrderItemExtensions
{
    public static class OrderItemModelItemsDAMapToOrderItemModelItemsBL
    {
        public static List<OrderItemModelItem> Map(this ICollection<DataAccess.Models.OrderItems.OrderItemModelItem> orderItemModelItems)
        {
            List<OrderItemModelItem> items = new List<OrderItemModelItem>();
            foreach (DataAccess.Models.OrderItems.OrderItemModelItem orderItemModelItem in orderItemModelItems)
            {
                items.Add(orderItemModelItem.Map());
            }
            return items;
        }
    }
}
