using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }

        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}