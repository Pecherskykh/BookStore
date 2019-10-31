using BookStore.BusinessLogic.Models.OrderItems;
using BookStore.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Cart
{
    public class Cart : BaseModel
    {
        public OrderItemModel OrderItemModel { get; set; }
        public long TransactionId { get; set; }
        public string Description { get; set; }
        public long userId { get; set; }
    }
}
