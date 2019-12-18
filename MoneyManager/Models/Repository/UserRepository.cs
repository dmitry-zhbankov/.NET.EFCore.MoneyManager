﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(MoneyContext context) : base(context)
        {
        }

        public override User GetById(int id)
        {
            return dbSet.Include(x => x.Assets).Include(x=>x.UserCategories).ThenInclude(y=>y.Category).FirstOrDefault(x => x.UserId == id);
        }

        public IEnumerable<User> GetByEmail(string email)
        {
            return Get(x => x.Email.ToLower().Contains(email.ToLower()));
        }
    }
}
