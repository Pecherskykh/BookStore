using System.Collections.Generic;
using BookStore.DataAccess.Entities.Base;
using static BookStore.DataAccess.Entities.Enums.Enums;
using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;

namespace BookStore.DataAccess.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; } //todo use decimal
        public string Status { get; set; } //todo remove
        public Currencys Currency { get; set; }
        public TypePrintingEditionEnum.Type Type { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } //todo add attr NotMapped
        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}
