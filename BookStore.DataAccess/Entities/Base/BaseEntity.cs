using System;

namespace BookStore.DataAccess.Entities.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
