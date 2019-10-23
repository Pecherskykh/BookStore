using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.Base
{
    public class BaseModel
    {
        public string SearchString { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
