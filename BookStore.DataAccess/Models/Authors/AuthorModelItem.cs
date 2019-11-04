using System.Collections.Generic;

namespace BookStore.DataAccess.Models.Authors
{
    public class AuthorModelItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> PrintingEditions = new List<string>();
    }
}
