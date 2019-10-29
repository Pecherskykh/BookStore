using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService : IBaseService<Author, IAuthorRepository>
    {
        Task Find(BaseModel aut);
        Task<AuthorModelItem> FindByIdAsync(long authorId);
        Task<AuthorModel> GetAuthorsAsync();
    }
}
