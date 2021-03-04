using System;
using System.Threading.Tasks;
using Tournament40.Service.DAL.Repository;
using Tournament40.Service.DAL.Repository.Contract;

namespace Tournament40.Service.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ITournametRepository Tournaments { get; }

        public IPlayerRepository Players { get; }
        
        private readonly TournamentContext dbContext;

        private bool disposed;

        public UnitOfWork(TournamentContext dbContext)
        {
            this.dbContext = dbContext;
            Tournaments = new TournametRepository(dbContext);
            Players = new PlayerRepository(dbContext);
        }

        public Task<int> CompleteAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }

        #region IDisposable
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        #endregion
    }
}