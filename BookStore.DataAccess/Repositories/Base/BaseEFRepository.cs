using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task CreateAsync(TEntity item)
        {
            var a = await _dbSet.AddAsync(item);
            await _applicationContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity item)
        {
            _applicationContext.Entry(item).State = EntityState.Modified;
            await _applicationContext.SaveChangesAsync();
        }
        public async Task RemoveAsync(TEntity item)
        {
            _dbSet.Remove(item);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
