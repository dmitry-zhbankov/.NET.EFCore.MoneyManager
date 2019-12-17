using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<UserCategory> UserCategories { get; set; }

        public User()
        {
            Assets = new List<Asset>();
            Transactions = new List<Transaction>();
        }

        public decimal Capital
        {
            get { return Assets.Sum(item => item.Balance); }
        }
    }
}