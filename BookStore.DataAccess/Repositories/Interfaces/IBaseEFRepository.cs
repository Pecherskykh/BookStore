using BookStore.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IBaseEFRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> FindByIdAsync(long id);
        Task<long> CreateAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task RemoveAsync(TEntity item);
        Task RemoveRangeAsync(IEnumerable<TEntity> item);
    }
}