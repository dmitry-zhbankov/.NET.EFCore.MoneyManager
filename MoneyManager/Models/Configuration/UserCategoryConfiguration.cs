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
        }
    }
}