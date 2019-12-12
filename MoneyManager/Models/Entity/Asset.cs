namespace MoneyManager.Models
{
    public class Asset
    {
        public int AssetId { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }
        
        public User User { get; set; }
    }
}
