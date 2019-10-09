using System;
using System.Collections.Generic;
using System.Text;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities.Enums
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}