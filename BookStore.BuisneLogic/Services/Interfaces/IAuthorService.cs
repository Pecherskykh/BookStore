using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        Task CreateAsync(Author author);
        Task<Author> GetAsync(long authorId);
        Task UpdateAsync();
        Task DeleteAsync(long authorId);
    }
}
