using Microsoft.EntityFrameworkCore;

namespace Money_Manager.Models
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(MoneyContext context):base(context)
        {
        }
    }
}
