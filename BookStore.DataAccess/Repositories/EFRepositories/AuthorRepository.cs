using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Interfaces;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _applicationContext;

        public AuthorRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task CreateAsync(Author author)
        {
            _applicationContext.Authors.Add(author);
            _applicationContext.SaveChanges();
        }

        public async Task<Author> GetAsync(long authorId)
        {
            return _applicationContext.Authors.FirstOrDefault(a => a.Id == authorId);
        }

        public async Task UpdateAsync()
        {
            _applicationContext.SaveChanges();
        }

        public async Task DeleteAsync(long authorId)
        {
            _applicationContext.Authors.Remove(await GetAsync(authorId));
            _applicationContext.SaveChanges();
        }
    }
}
