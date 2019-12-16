using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models
{
    public class Asset
    {
        public int AssetId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Balance { get; set; }
        
        [Required]
        public User User { get; set; }
    }
}
