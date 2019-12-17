using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MoneyContext context) : base(context)
        {
        }

        public override Category GetById(int id)
        {
            return dbSet.Include(x => x.Children).FirstOrDefault(y => y.CategoryId == id);
        }
    }
}
