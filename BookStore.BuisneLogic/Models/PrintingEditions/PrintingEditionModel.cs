using BookStore.BusinessLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public ICollection<PrintingEditionModelItem> Items = new List<PrintingEditionModelItem>();
    }
}
