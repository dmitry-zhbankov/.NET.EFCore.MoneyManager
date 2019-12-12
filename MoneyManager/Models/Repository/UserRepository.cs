using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Models
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(MoneyContext context):base(context)
        {
        }
    }
}
