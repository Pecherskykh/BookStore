using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService : IBaseService<AuthorModelItem>
    {
        Task<AuthorModel> GetAuthorsAsync(BaseFilterModel baseFilterModel);
        Task<AuthorModel> GetAllAuthors();
    }
}
