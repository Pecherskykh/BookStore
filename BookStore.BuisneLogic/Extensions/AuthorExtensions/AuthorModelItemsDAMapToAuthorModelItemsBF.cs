using BookStore.BusinessLogic.Models.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions.AuthorExtensions
{
    public static class AuthorModelItemsDAMapToAuthorModelItemsBF
    {
        public static List<AuthorModelItem> Map(this ICollection<BookStore.DataAccess.Models.Authors.AuthorModelItem> authorModelItems)
        {
            List<AuthorModelItem> author = new List<AuthorModelItem>();
            foreach (BookStore.DataAccess.Models.Authors.AuthorModelItem authorModelItem in authorModelItems)
            {
                author.Add(authorModelItem.Map());
            }
            return author;
        }
    }
}
