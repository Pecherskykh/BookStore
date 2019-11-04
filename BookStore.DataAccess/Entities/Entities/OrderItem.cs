using System.ComponentModel.DataAnnotations.Schema;
using BookStore.DataAccess.Entities.Base;
using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;

namespace BookStore.DataAccess.Entities.Enums
{
    public class OrderItem : BaseEntity
    {
        public int Amount { get; set; }
        public Currencys Currency { get; set; }
        public int Count { get; set; }
        public int PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
