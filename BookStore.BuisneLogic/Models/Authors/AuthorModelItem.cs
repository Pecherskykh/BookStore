using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Authors
{
    public class AuthorModelItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> PrintingEditions = new List<string>();
    }
}
