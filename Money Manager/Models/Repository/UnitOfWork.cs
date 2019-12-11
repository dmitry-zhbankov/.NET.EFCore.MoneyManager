using Microsoft.EntityFrameworkCore;
using System;

namespace Money_Manager.Models
{
    public class UnitOfWork : IDisposable
    {
        MoneyContext context;
        static UnitOfWork instance;

        public static UnitOfWork GetInstance(MoneyContext context)
        {
            if (instance==null)
            {
                instance = new UnitOfWork(context);
            }
            return instance;
        }
        UnitOfWork(MoneyContext context)
        {
            this.context = context;
        }

        public UserRepository userRepository;
        UserRepository UserRepository
        {
            get
            {
                if (userRepository==null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public AssetRepository assetRepository;
        AssetRepository AssetRepository
        {
            get
            {
                if (assetRepository == null)
                {
                    assetRepository = new AssetRepository(context);
                }
                return assetRepository;
            }
        }

        public CategoryRepository categoryRepository;
        CategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        public TransactionRepository transactionRepository;
        TransactionRepository TransactionRepository
        {
            get
            {
                if (transactionRepository == null)
                {
                    transactionRepository = new TransactionRepository(context);
                }
                return transactionRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
