using BookStore.BusinessLogic.Models.Authors;
using BookStore.DataAccess.Models.Base;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService : IBaseService<AuthorModelItem>
    {
        Task<AuthorModel> GetAuthorsAsync(BaseFilterModel baseFilterModel);
    }
}
