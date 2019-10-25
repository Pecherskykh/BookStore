using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<BaseModel> CreateAsync(Author author)
        {
            await _authorRepository.CreateAsync(author);
            return new BaseModel();
        }

        public async Task<Author> FindByIdAsync(long authorId)
        {
            return await _authorRepository.FindByIdAsync(authorId);
        }

        public async Task<BaseModel> UpdateAsync(Author author)
        {
            await _authorRepository.UpdateAsync(author);
            return new BaseModel();
        }

        public async Task<BaseModel> DeleteAsync(Author author)
        {
            await _authorRepository.RemoveAsync(author);
            return new BaseModel();
        }

        public async Task<AuthorModel> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAuthorsAsync();
            var resultModel = new AuthorModel();
            foreach (var author in authors)
            {
                resultModel.Items.Add(author.Mapping());
            }
            return resultModel;
        }
    }
}
