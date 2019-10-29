using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.BaseService
{
    public class BaseService<TEntity, IBaseEFRepository> : IBaseService<TEntity, IBaseEFRepository> where IBaseEFRepository : IBaseEFRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseEFRepository _baseEFRepository;

        public BaseService(IBaseEFRepository baseEFRepository)
        {
            _baseEFRepository = baseEFRepository;
        }

        public async Task<BaseModel> CreateAsync(TEntity tEntity)
        {

            await _baseEFRepository.CreateAsync(tEntity);
            return new BaseModel();
        }        

        public async Task<BaseModel> UpdateAsync(TEntity tEntity)
        {
            await _baseEFRepository.UpdateAsync(tEntity);
            return new BaseModel();
        }

        public async Task<BaseModel> RemoveAsync(TEntity tEntity)
        {
            await _baseEFRepository.RemoveAsync(tEntity);
            return new BaseModel();
        }
    }
}
