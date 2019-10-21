using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task CreateAsync(Author author);
        Task<Author> GetAsync(long authorId);
        Task UpdateAsync();
        Task DeleteAsync(long authorId);
    }
}
