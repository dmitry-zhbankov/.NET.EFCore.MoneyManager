using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoneyManager.Models
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasData(CreateAssets());
        }

        ICollection<object> CreateAssets()
        {
            var list = new List<object>();
            var counter = 1;
            for (int i = 1; i <= 10; i++)
            {
                list.Add(
                    new
                    {
                        AssetId = counter,
                        Name = $"User{i}Asset1",
                        Balance = new decimal(0),
                        UserId = i
                    }
                );
                counter++;
                list.Add(
                    new
                    {
                        AssetId = counter,
                        Name = $"User{i}Asset2",
                        Balance = new decimal(0),
                        UserId = i
                    }
                );
                counter++;
            }

            return list;
        }
    }
}