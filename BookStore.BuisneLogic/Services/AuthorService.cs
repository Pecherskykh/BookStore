using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Services
{
    class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorModelItem> FindByIdAsync(long authorId)
        {
            var resultModel = new AuthorModelItem();
            var author = await _authorRepository.FindByIdAsync(authorId);
            if (author == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return author.Mapping();
        }

        public async Task<long> CreateAsync(AuthorModelItem author)
        {
            return await _authorRepository.CreateAsync(author.Mapping());
        }

        public async Task<BaseModel> UpdateAsync(AuthorModelItem author)
        {
            await _authorRepository.UpdateAsync(author.Mapping());
            return new BaseModel();
        }

        public async Task<BaseModel> RemoveAsync(AuthorModelItem author)
        {
            author.IsRemoved = true;
            await _authorRepository.UpdateAsync(author.Mapping());
            return new BaseModel();
        }

        public async Task<AuthorModel> GetAuthorsAsync(SortingDirection sortingDirection)
        {
            var authors = await _authorRepository.GetAuthorsAsync(sortingDirection);
            var resultModel = new AuthorModel();
            foreach (var author in authors)
            {
                resultModel.Items.Add(author.Mapping());
            }
            return resultModel;
        }
    }
}