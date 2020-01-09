using BookStore.BusinessLogic.Models.Authors;

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
