using BookStore.BusinessLogic.Models.Authors;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.AuthorExtensions
{
    public static class AuthorModelItemMapToAuthor
    {
        public static Author Map(this AuthorModelItem author)
        {
            return new Author()
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}
