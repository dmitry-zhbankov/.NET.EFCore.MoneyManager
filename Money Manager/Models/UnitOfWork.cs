using System;

namespace Money_Manager.Models
{
    public class UnitOfWork : IDisposable
    {
        MoneyContext context = new MoneyContext();
        UserRepository userRepository;
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
        AssetRepository assetRepository;
        UserRepository AssetRepository
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
        CategoryRepository categoryRepository;
        UserRepository CategoryRepository
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
        TransactionRepository transactionRepository;
        UserRepository TransactionRepository
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
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
