using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MoneyContext context) : base(context)
        {
        }

        public override Category GetById(int id)
        {
            return dbSet.Include(x => x.Children).FirstOrDefault(y => y.CategoryId == id);
        }

        public override IEnumerable<Category> Get(Expression<Func<Category, bool>> filter)
        {
            var categories = dbSet.Where(filter).Include(x => x.UserCategories).Include(x => x.Children);
            return categories.ToList();
        }
    }
}