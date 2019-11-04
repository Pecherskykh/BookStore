using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.Orders
{
    public class OrderModel
    {
        public ICollection<OrderModelItem> Items = new List<OrderModelItem>();
    }
}
