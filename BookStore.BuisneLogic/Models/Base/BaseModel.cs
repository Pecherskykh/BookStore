using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.Base
{
    public class BaseModel
    {
        public ICollection<string> Errors { get; set; } = new List<string>();
        public bool IsRemoved { get; set; }
    }
}
