using BookStore.BusinessLogic.Models.Base;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.Authors
{
    public class AuthorModel : BaseModel
    {
        public long PageAmount { get; set; }
        public ICollection<AuthorModelItem> Items { get; set; }
    }
}