using BookStore.DataAccess.Models.OrderItems;
using System;
using System.Collections.Generic;

namespace BookStore.DataAccess.Models.Orders
{
    public class OrderModelItem
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public ICollection<OrderItemModelItem> OrderItems { get; set; }
        public long OrderAmount { get; set; }
    }
}
