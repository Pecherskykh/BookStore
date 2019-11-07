using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Extensions.PrintingEditionExtensions
{
    public static class PrintingEditionMapToPrintingEditionModelItem
    {
        public static PrintingEditionModelItem Map(this PrintingEdition printingEditionModelItem)
        {
            return new PrintingEditionModelItem()
            {
                Id = printingEditionModelItem.Id,
                IsRemoved = printingEditionModelItem.IsRemoved,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                ProductType = (TypePrintingEdition)printingEditionModelItem.Type,
            };
        }
    }
}
