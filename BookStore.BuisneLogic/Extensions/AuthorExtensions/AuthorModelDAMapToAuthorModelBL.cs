using BookStore.BusinessLogic.Models.Authors;

namespace BookStore.BusinessLogic.Extensions.AuthorExtensions
{
    public static class AuthorModelDAMapToAuthorModelBL
    {
        public static AuthorModel Map(this DataAccess.Models.Authors.AuthorModel authorModel)
        {
            return new AuthorModel()
            {
                PageAmount = authorModel.PageAmount,
                Items = authorModel.Items.Map()
            };
        }
    }
}
