using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Base
{
    public class BaseModel
    {
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
