using System;
using System.Collections.Generic;
using System.Text;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities.Enums
{
    public class Payment : BaseEntity
    {
        public int TransactionId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
