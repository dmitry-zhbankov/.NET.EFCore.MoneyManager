using Microsoft.EntityFrameworkCore;
using System;

namespace MoneyManager.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        MoneyContext context;
        bool disposed;

        public DbContext Context => context;
        public IUserRepository UserRepository { get; }
        public IAssetRepository AssetRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ITransactionRepository TransactionRepository { get; }

        public UnitOfWork(MoneyContext context, IUserRepository userRepository, IAssetRepository assetRepository, ICategoryRepository categoryRepository, ITransactionRepository transactionRepository)
        {
            this.context = context;
            UserRepository = userRepository;
            AssetRepository = assetRepository;
            CategoryRepository = categoryRepository;
            TransactionRepository = transactionRepository;
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
                context.Dispose();
            }

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