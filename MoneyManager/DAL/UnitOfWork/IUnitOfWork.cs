using System;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IUserRepository UserRepository { get; }

        IAssetRepository AssetRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        int Save();
    }
}