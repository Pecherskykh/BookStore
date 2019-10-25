using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.Authors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseEFRepository<Author>
    {
        Task<IEnumerable<AuthorModelItem>> GetAuthorsAsync();
    }
}
