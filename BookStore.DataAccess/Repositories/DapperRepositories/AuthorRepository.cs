using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Models.Authors;
using BookStore.DataAccess.Models.Base;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.DapperRepositories
{
    public class AuthorRepository: BaseDapperRepository<Author>, IAuthorRepository
    {
        public async Task<AuthorModel> GetAuthorsAsync(BaseFilterModel baseFilterModel)
        {
            var resultModel = new AuthorModel();
            resultModel.PageAmount = 1;
            resultModel.Items = new List<AuthorModelItem>();
            resultModel.Items.Add(new AuthorModelItem()
            {
                Id = 7,
                Name = "Igor"
            });
            return resultModel;
        }
    }
}
