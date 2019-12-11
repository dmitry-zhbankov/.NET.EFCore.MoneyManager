using Microsoft.EntityFrameworkCore;

namespace Money_Manager.Models
{
    public class MoneyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        
        public MoneyContext(DbContextOptions options):base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                        
            base.OnConfiguring(optionsBuilder);
        }
    }
}
