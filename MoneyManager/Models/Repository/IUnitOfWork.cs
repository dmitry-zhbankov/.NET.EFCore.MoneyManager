using System;

namespace MoneyManager.Models
{
    public interface IUnitOfWork: IDisposable
    {
        UserRepository UserRepository { get; }
        AssetRepository AssetRepository { get; }
        CategoryRepository CategoryRepository { get; }
        TransactionRepository TransactionRepository { get; }
        void Save();
    }
}