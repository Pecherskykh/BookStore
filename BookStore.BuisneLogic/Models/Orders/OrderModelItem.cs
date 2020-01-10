using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.OrderItems;
using System;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.Orders
{
    public class OrderModelItem : BaseModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PaymentId { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public ICollection<OrderItemModelItem> OrderItems { get; set; } = new List<OrderItemModelItem>();
        public decimal OrderAmount { get; set; }
    }
}