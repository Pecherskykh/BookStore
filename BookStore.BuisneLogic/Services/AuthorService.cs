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

        public async Task CreateAsync(Author author)
        {
            await _authorRepository.CreateAsync(author);
        }

        public async Task<Author> GetAsync(long authorId)
        {
            return await _authorRepository.GetAsync(authorId);
        }

        public async Task UpdateAsync()
        {
            await _authorRepository.UpdateAsync();
        }

        public async Task DeleteAsync(long authorId)
        {
            await _authorRepository.DeleteAsync(authorId);
        }
    }
}
