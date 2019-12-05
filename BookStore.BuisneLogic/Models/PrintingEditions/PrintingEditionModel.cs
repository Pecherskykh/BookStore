using BookStore.BusinessLogic.Models.Base;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public long CountPrintingEditions { get; set; }
        public ICollection<PrintingEditionModelItem> Items { get; set; } = new List<PrintingEditionModelItem>();
    }
}
