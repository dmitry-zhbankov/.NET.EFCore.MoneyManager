using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class UserCategory
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public  Category Category { get; set; }
    }
}
