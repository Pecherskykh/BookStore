using System;
using System.Collections.Generic;
using System.Text;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities.Enums
{
    public class OrderItem : BaseEntity
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int Count { get; set; }
        public int PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
