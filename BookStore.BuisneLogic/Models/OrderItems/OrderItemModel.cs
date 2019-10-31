using BookStore.BusinessLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.OrderItems
{
    public class OrderItemModel : BaseModel
    {
        public ICollection<OrderItemModelItem> Items = new List<OrderItemModelItem>();
    }
}
