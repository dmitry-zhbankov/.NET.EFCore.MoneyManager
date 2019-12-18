using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public class TransactionRepository : GenericRepository<Transaction>
    {
        public TransactionRepository(MoneyContext context) : base(context)
        {
        }

        public override IEnumerable<Transaction> Get(Expression<Func<Transaction, bool>> filter)
        {
            IQueryable<Transaction> query = dbSet;
            query = query.Where(filter).Include(x => x.Category).Include(x => x.Asset).Include(x => x.User)
                .OrderByDescending(x => x.Date);
            return query.ToList();
        }
        public IEnumerable<Transaction> GetUserTransactions(int userId)
        {
            var transactions = Get(x => x.User.UserId == userId).OrderByDescending(x => x.Date)
                .ThenBy(x => x.Asset.Name).ThenBy(x => x.Category.Name);
            return transactions;
        }

        public void DeleteAllUserMonthTransactions(int userId)
        {
            var transactions = dbSet.Where(x => x.Date.Month == DateTime.Now.Month&&x.Date.Year==DateTime.Now.Year && x.User.UserId == userId);
            dbSet.RemoveRange(transactions);
        }
    }
}
