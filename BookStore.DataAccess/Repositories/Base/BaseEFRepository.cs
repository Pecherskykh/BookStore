using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Base
{
    public class BaseEFRepository<TEntity> : IBaseEFRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _applicationContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseEFRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbSet = applicationContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public async Task<TEntity> FindByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<long> CreateAsync(TEntity item)
        {
            var entity = await _dbSet.AddAsync(item);
            await _applicationContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<bool> CreateRangeAsync(ICollection<TEntity> item)
        {
            await _dbSet.AddRangeAsync(item);
            var result = await _applicationContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }
        public async Task<bool> UpdateAsync(TEntity item)
        {
            _applicationContext.Entry(item).State = EntityState.Modified;
            var result = await _applicationContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }
        public async Task<bool> RemoveAsync(TEntity item)
        {
            _dbSet.Remove(item);
            var result = await _applicationContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> item)
        { 
            _dbSet.RemoveRange(item);
            var result = await _applicationContext.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> IsRemoveAsync(TEntity item)
        {
            item.IsRemoved = true;
            var result = await UpdateAsync(item);
            return result;
        }
    }
}
