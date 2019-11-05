using BookStore.BusinessLogic.Models.Base;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.Authors
{
    public class AuthorModelItem : BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> PrintingEditionsName = new List<string>();
    }
}
