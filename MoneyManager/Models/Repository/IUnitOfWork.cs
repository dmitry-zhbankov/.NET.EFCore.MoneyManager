using System;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public interface IUnitOfWork: IDisposable
    {
        DbContext Context { get; }
        UserRepository UserRepository { get; }

        AssetRepository AssetRepository { get; }

        CategoryRepository CategoryRepository { get; }

        TransactionRepository TransactionRepository { get; }

        int Save();
    }
}