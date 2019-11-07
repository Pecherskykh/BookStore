using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.PrintingEditionExtensions
{
    public static class PrintingEditionModelItemMapToPrintingEdition
    {
        public static PrintingEdition Map(this PrintingEditionModelItem printingEditionModelItem)
        {
            return new PrintingEdition()
            {
                Id = printingEditionModelItem.Id,
                IsRemoved = printingEditionModelItem.IsRemoved,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Type = (DataAccess.Entities.Enums.Enums.TypePrintingEdition)printingEditionModelItem.ProductType,
            };
        }
    }
}
