using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities
{
    public class Order : BaseEntity
    {

        [ForeignKey("PaymentId")]
        public long PaymentId { get; set; }

        [ForeignKey("UserId")]
        public long UserId { get; set; }
        public long Amount { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}