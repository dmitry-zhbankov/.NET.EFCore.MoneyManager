using System.Collections.Generic;

namespace MoneyManager.Models
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MoneyContext context):base(context)
        {
        }
    }
}
