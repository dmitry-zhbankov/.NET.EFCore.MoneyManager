using System.Collections.Generic;

namespace MoneyManager.Models
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByEmail(string email);
    }
}