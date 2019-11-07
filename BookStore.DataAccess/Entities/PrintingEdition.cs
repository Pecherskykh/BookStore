using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.DataAccess.Entities.Base;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.DataAccess.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currencys Currency { get; set; }
        public TypePrintingEdition Type { get; set; }

        [NotMapped]
        public ICollection<OrderItem> OrderItems { get; set; }

        [NotMapped]
        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}
