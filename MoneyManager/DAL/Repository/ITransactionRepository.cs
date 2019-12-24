using System.Collections.Generic;

namespace MoneyManager.Models
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        void DeleteAllUserMonthTransactions(int userId);

        IEnumerable<Transaction> GetUserTransactions(int userId);
    }
}