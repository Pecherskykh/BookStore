using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions.AuthorExtensions;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Extensions.BaseFilterExtensions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorModelItem> FindByIdAsync(long authorId)
        {
            var resultModel = new AuthorModelItem();
            if(authorId == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorIdIsZeroError);
                return resultModel;
            }
            var author = await _authorRepository.FindByIdAsync(authorId);
            if (author == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorNotFoundError);
                return resultModel;
            }
            return author.Map();
        }

        public async Task<BaseModel> CreateAsync(AuthorModelItem author)
        {
            var resultModel = new BaseModel();
            if (author == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorModelItemIsEmptyError);
                return resultModel;
            }

            if (string.IsNullOrWhiteSpace(author.Name))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorNameIsMissingError);
                return resultModel;
            }

            var result = await _authorRepository.CreateAsync(author.Map());
            if(result == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorNotCreatedError);
                return resultModel;
            }
            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(AuthorModelItem author)
        {
            var resultModel = new BaseModel();
            if (author == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorModelItemIsEmptyError);
                return resultModel;
            }

            if (string.IsNullOrWhiteSpace(author.Name))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorNameIsMissingError);
                return resultModel;
            }

            var result = await _authorRepository.UpdateAsync(author.Map());
            if(!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.DataNotUpdatedError);
            }
            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(AuthorModelItem author)
        {
            var resultModel = new BaseModel();
            if (author == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.AuthorModelItemIsEmptyError);
                return resultModel;
            }
            var result = await _authorRepository.IsRemoveAsync(author.Map());
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.DataNotRemovedError);
                return resultModel;
            }
            return new BaseModel();
        }

        public async Task<AuthorModel> GetAuthorsAsync(BaseFilterModel baseFilterModel)
        {
            var resultModel = new AuthorModel();
            if (baseFilterModel == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.BaseFilterModelIsEmptyError);
                return resultModel;
            }
            var authors = await _authorRepository.GetAuthorsAsync(baseFilterModel.Map());
            var a = _authorRepository.Get(b => true);
            resultModel = authors.Map();
            return resultModel;
        }

        public async Task<AuthorModel> GetAllAuthors()
        {
            var resultModel = new AuthorModel();
            var authors = _authorRepository.Get(a => !a.IsRemoved);
            foreach(var author in authors)
            {
                resultModel.Items.Add(author.Map());
            }
            return resultModel;
        }
    }
}