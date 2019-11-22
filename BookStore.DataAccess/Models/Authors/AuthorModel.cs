using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.Authors
{
    public class AuthorModel
    {
        public int PageAmount { get; set; }
        public ICollection<AuthorModelItem> Items { get; set; }
    }
}
