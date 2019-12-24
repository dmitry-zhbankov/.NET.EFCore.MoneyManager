using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MoneyContext context) : base(context)
        {
        }

        public override IEnumerable<User> Get(Expression<Func<User, bool>> filter)
        {
            var users = dbSet.Where(filter).Include(x => x.Assets);
            return users.ToList();
        }

        public override User GetById(int id)
        {
            return dbSet.Include(x => x.Assets).Include(x => x.UserCategories).ThenInclude(y => y.Category)
                .FirstOrDefault(x => x.UserId == id);
        }

        public IEnumerable<User> GetByEmail(string email)
        {
            return Get(x => x.Email.ToLower().Contains(email.ToLower()));
        }
    }
}