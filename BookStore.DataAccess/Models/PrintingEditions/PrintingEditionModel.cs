using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.PrintingEditions
{
    public class PrintingEditionModel
    {
        public long CountPrintingEditions { get; set; }
        public ICollection<PrintingEditionModelItem> Items { get; set; }
    }
}
