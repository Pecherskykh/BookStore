using System;
using System.Collections.Generic;
using System.Text;
using BookStore.DataAccess.Entities.Base;
using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;

namespace BookStore.DataAccess.Entities.Enums
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public Currencys Currency { get; set; }
        public string Type { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}
