using System.Collections.Generic;

namespace Money_Manager.Models
{
    public class TransactionRepository : GenericRepository<Transaction>
    {
        public TransactionRepository(MoneyContext context) : base(context)
        {
        }
    }
}
