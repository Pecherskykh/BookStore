using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Base
{
    public class BaseDapperRepository<TEntity> : IBaseEFRepository<TEntity> where TEntity : BaseEntity
    {
        string connectionString = "Server=DESKTOP-4C8DBJI;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true";

        public BaseDapperRepository()
        {

        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.GetAllAsync<TEntity>();
            }
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return null;
        }
        public async Task<TEntity> FindByIdAsync(long id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.GetAsync<TEntity>(id);
            }
        }

        public async Task<long> CreateAsync(TEntity item)
        {
            item.CreationDate = DateTime.Now;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.InsertAsync(item); 
            }
        }

        public async Task<bool> CreateRangeAsync(ICollection<TEntity> item)
        {
            return true;
        }
        public async Task<bool> UpdateAsync(TEntity item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.UpdateAsync(item);
            }
        }
        public async Task<bool> RemoveAsync(TEntity item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.DeleteAsync(item);
            }
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> item)
        {
            return false;
        }

        public async Task<bool> IsRemoveAsync(TEntity item)
        {
            item.IsRemoved = true;
            return await UpdateAsync(item);
        }
    }
}
