using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Extensions.AuthorExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Extensions.PrintingEditionExtensions
{
    public static class PrintingEditionModelItemDAMapToPrintingEditionModelItemBL
    {
        public static PrintingEditionModelItem Map(this BookStore.DataAccess.Models.PrintingEditions.PrintingEditionModelItem printingEditionModelItem)
        {
            return new PrintingEditionModelItem()
            {
                Id = printingEditionModelItem.Id,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                ProductType = (TypePrintingEdition)printingEditionModelItem.Type,
                Authors = new AuthorModel()
                {
                    Items = printingEditionModelItem.Authors.Map()
                }
            };
        }
    }
}
