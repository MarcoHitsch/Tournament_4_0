using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tournament40.Service.DAL.Repository.Contract;

namespace Tournament40.Service.DAL.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly DbContext context;

        private bool disposed;

        protected BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            return this.context.Set<TEntity>().AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return this.context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.context.Set<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public ValueTask<TEntity> GetAsync(Guid id)
        {
            return this.context.Set<TEntity>().FindAsync(id);
        }

        public Task RemoveAsync(TEntity entity)
        {
            return Task.Run(() => { this.context.Set<TEntity>().Remove(entity); });
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            return Task.Run(() => { this.context.Set<TEntity>().RemoveRange(entities); });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
