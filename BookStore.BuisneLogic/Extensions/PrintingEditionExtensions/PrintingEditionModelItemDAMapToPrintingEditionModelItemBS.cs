using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.PrintingEditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.PrintingEditionExtensions
{
    public static class PrintingEditionModelItemDAMapToPrintingEditionModelItemBS
    {
        public static PrintingEditionModelItem Map(this BookStore.DataAccess.Models.PrintingEditions.PrintingEditionModelItem printingEditionModelItem)
        {
            return new PrintingEditionModelItem()
            {
                Id = printingEditionModelItem.Id,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Type = printingEditionModelItem.Type,
                Authors = new AuthorModel()
                {
                    Items = printingEditionModelItem.Authors.Mapping()
                }
            };
        }
    }
}
