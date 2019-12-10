using System.Linq;
using System.Threading.Tasks;

namespace Money_Manager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Asset Assets { get; set; }
        public Transaction Transactions { get; set; }
    }
}
