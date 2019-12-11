using System.ComponentModel.DataAnnotations.Schema;
using BookStore.DataAccess.Entities.Base;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.DataAccess.Entities
{
    public class OrderItem : BaseEntity
    {
        public long Count { get; set; }
        public long PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }

        [ForeignKey("OrderId")]
        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
