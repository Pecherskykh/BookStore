using BookStore.BusinessLogic.Models.PrintingEditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.PrintingEditionExtensions
{
    public static class PrintingEditionModelDAMapToPrintingEditionBL
    {
        public static PrintingEditionModel Map(this DataAccess.Models.PrintingEditions.PrintingEditionModel printingEditionModel)
        {
            var items = new List<PrintingEditionModelItem>();

            foreach (var item in printingEditionModel.Items)
            {
                items.Add(item.Map());
            }

            return new PrintingEditionModel()
            {
                CountPrintingEditions = printingEditionModel.CountPrintingEditions,
                Items = items
            };
        }
    }
}
