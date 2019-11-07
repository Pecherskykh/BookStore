using System;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.DataAccess.Models.Orders
{
    public class OrderModelItem
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public TypePrintingEdition Product { get; set; }
        public string Title { get; set; }
        public long Quantity { get; set; }
        public long OrderAmount { get; set; }
    }
}
