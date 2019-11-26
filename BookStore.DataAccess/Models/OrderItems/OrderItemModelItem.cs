using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.DataAccess.Models.OrderItems
{
    public class OrderItemModelItem
    {
        public TypePrintingEdition Type { get; set; }
        public string Title { get; set; }
        public long Count { get; set; }
    }
}
