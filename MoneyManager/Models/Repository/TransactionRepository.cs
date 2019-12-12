using System.Collections.Generic;

namespace MoneyManager.Models
{
    public class TransactionRepository : GenericRepository<Transaction>
    {
        public TransactionRepository(MoneyContext context) : base(context)
        {
        }
    }
}
