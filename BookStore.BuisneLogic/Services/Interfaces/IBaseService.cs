using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IBaseService<TEntity, IBaseEFRepository> where IBaseEFRepository : IBaseEFRepository<TEntity> where TEntity : BaseEntity
    {
        Task<BaseModel> CreateAsync(TEntity item);
        Task<BaseModel> UpdateAsync(TEntity item);
        Task<BaseModel> RemoveAsync(TEntity item);
    }
}
