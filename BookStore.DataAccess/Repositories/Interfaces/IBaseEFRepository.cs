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
        Task<bool> CreateRangeAsync(ICollection<TEntity> item);
        Task<bool> UpdateAsync(TEntity item);
        Task<bool> RemoveAsync(TEntity item);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> item);
        Task<bool> IsRemoveAsync(TEntity item);
    }
}