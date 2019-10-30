using BookStore.DataAccess.Models.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.PrintingEditions
{
    public class PrintingEditionModelItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public ICollection<AuthorModelItem> Authors { get; set; }
    }
}
