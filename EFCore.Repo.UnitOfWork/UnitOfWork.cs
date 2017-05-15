using EFCore.Repo.Context;
using EFCore.Repo.Interfaces;
using System;

namespace EFCore.Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _databaseContext;
        private bool _disposed = false;

        public UnitOfWork(ApplicationContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

            _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _databaseContext != null)
            {
                _databaseContext.Dispose();
            }

            _disposed = true;
        }
    }
}
