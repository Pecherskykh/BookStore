using BookStore.BusinessLogic.Models.Authors;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.AuthorExtensions
{
    public static class AuthorMapToAuthorModelItem
    {
        public static AuthorModelItem Map(this Author author)
        {
            return new AuthorModelItem()
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}
