using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseEFRepository<Author>
    {
        Task<IEnumerable<AuthorModelItem>> GetAuthorsAsync(SortingDirection sortingDirection);
    }
}
