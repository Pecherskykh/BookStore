using BookStore.DataAccess.Common.Constants;
using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Base
{
    public class BaseDapperRepository<TEntity> : IBaseEFRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly string _connectionString;

        public BaseDapperRepository()
        {
            _connectionString = Constants.DapperConstants.connectionString;
        }


        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.GetAllAsync<TEntity>();
            }
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return null;
        }
        public async Task<TEntity> FindByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.GetAsync<TEntity>(id);
            }
        }

        public async Task<long> CreateAsync(TEntity item)
        {
            item.CreationDate = DateTime.Now;
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.InsertAsync(item); 
            }
        }

        public async Task<bool> CreateRangeAsync(ICollection<TEntity> item)
        {
            return true;
        }
        public async Task<bool> UpdateAsync(TEntity item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.UpdateAsync(item);
            }
        }
        public async Task<bool> RemoveAsync(TEntity item)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                return await connection.DeleteAsync(item);
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
