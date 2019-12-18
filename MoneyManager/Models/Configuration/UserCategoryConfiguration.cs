using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoneyManager.Models
{
    public class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
    {
        public void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            builder.HasKey(t => new {t.UserId, t.CategoryId});

            builder.HasOne(pt => pt.User)
                .WithMany(p => p.UserCategories)
                .HasForeignKey(pt => pt.UserId);

            builder.HasOne(pt => pt.Category)
                .WithMany(t => t.UserCategories)
                .HasForeignKey(pt => pt.CategoryId);

            builder.HasData(CreateUserCategories());
        }

        IEnumerable<object> CreateUserCategories()
        {
            List<object> list = new List<object>();
            for (var i = 1; i <= 10; i++)
            {
                for (var j = 1; j <= i*6; j++) 
                {
                    list.Add(
                        new
                        {
                            UserId = i,
                            CategoryId = j
                        }
                    );
                }
            }

            return list;
        }
    }
}