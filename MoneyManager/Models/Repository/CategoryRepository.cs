using System.Collections.Generic;

namespace Money_Manager.Models
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(MoneyContext context):base(context)
        {
        }
    }
}
