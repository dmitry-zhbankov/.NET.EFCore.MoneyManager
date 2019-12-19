using Microsoft.EntityFrameworkCore;
using System;

namespace MoneyManager.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        MoneyContext context;
        bool disposed;

        public UnitOfWork(MoneyContext context)
        {
            this.context = context;
        }

        UserRepository userRepository;

        public DbContext Context => context;

        public UserRepository UserRepository
        {
            get { return userRepository ??= new UserRepository(context); }
        }

        AssetRepository assetRepository;
        public AssetRepository AssetRepository
        {
            get { return assetRepository ??= new AssetRepository(context); }
        }

        CategoryRepository categoryRepository;
        public CategoryRepository CategoryRepository
        {
            get { return categoryRepository ??= new CategoryRepository(context); }
        }

        TransactionRepository transactionRepository;
        public TransactionRepository TransactionRepository
        {
            get { return transactionRepository ??= new TransactionRepository(context); }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
                context.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
