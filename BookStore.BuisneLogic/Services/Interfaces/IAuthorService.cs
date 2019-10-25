using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<BaseModel> CreateAsync(Author author);
        Task<Author> FindByIdAsync(long authorId);
        Task<BaseModel> UpdateAsync(Author author);
        Task<BaseModel> DeleteAsync(Author author);
        Task<AuthorModel> GetAuthorsAsync();
    }
}
