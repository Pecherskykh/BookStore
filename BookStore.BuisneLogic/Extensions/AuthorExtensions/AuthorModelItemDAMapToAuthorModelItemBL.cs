using BookStore.BusinessLogic.Models.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.AuthorExtensions
{
    public static class AuthorModelItemDAMapToAuthorModelItemBL
    {
        public static AuthorModelItem Map(this BookStore.DataAccess.Models.Authors.AuthorModelItem author)
        {
            return new AuthorModelItem()
            {
                Id = author.Id,
                Name = author.Name,
                PrintingEditionsName = author.PrintingEditions
            };
        }
    }
}
