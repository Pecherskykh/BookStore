using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Models.Authors;
using BookStore.DataAccess.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseEFRepository<Author>
    {
        Task<IEnumerable<AuthorModelItem>> GetAuthorsAsync(BaseFilterModel baseFilterModel);
    }
}
