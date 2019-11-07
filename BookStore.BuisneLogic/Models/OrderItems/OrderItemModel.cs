using BookStore.BusinessLogic.Models.Base;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.OrderItems
{
    public class OrderItemModel : BaseModel
    {
        public ICollection<OrderItemModelItem> Items { get; set; }
    }
}
