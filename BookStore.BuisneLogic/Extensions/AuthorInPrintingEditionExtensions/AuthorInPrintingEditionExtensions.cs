using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.AuthorInPrintingEditionExtensions
{
    public static class AuthorInPrintingEditionExtensions
    {
        public static AuthorInPrintingEdition Map(this PrintingEditionModelItem printingEditionModelItem, AuthorModelItem authorModelItem)
        {
            return new AuthorInPrintingEdition()
            {
                AuthorId = authorModelItem.Id,
                PrintingEditionId = printingEditionModelItem.Id
            };
        }
    }
}