using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Services.BaseService;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class AuthorService : BaseService<Author, IAuthorRepository>, IAuthorService
    {
        public AuthorService(IAuthorRepository _baseEFRepository) : base(_baseEFRepository)
        {
        }

        public async Task<AuthorModelItem> FindByIdAsync(long authorId)
        {
            var resultModel = new AuthorModelItem();
            var author = await _baseEFRepository.FindByIdAsync(authorId);
            if (author == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return author.Mapping();
        }

        public async Task Find(BaseModel aut)
        {
            var abc = (AuthorModelItem)aut;
        }

        public async Task<AuthorModel> GetAuthorsAsync()
        {
            var authors = await _baseEFRepository.GetAuthorsAsync();
            var resultModel = new AuthorModel();
            foreach (var author in authors)
            {
                resultModel.Items.Add(author.Mapping());
            }
            return resultModel;
        }
    }
}