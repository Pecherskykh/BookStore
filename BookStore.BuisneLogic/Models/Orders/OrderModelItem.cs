using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.PrintingEditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Orders
{
    public class OrderModelItem : BaseModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Product { get; set; }
        public string Title { get; set; }
        public long Quantity { get; set; }
        public long OrderAmount { get; set; }
        public string Status { get; set; }
    }
}
