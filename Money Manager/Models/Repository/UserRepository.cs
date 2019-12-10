using Microsoft.EntityFrameworkCore;

namespace Money_Manager.Models
{
    public class UserRepository : IRepository<User>
    {
        MoneyContext context;
        DbSet<User> dbSet;
        public UserRepository(MoneyContext context)
        {

        }
    }
}
