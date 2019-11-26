using System.Collections.Generic;

namespace BookStore.DataAccess.Models.Orders
{
    public class OrderModel
    {
        public long PageAmount { get; set; }
        public ICollection<OrderModelItem> Items { get; set; }
    }
}
