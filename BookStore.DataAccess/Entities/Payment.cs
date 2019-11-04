using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public long TransactionId { get; set; }
    }
}
