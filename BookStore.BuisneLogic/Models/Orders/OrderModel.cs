using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Orders
{
    public class OrderModel
    {
        public ICollection<OrderModelItem> Items = new List<OrderModelItem>();
    }
}
