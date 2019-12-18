using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoneyManager.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }

        IEnumerable<User> CreateUsers()
        {
            var list=new List<User>();
            for (var i = 1; i <= 10; i++)
            {
                list.Add(
                        new User
                        {
                            UserId = i,
                            Name = $"User{i}",
                            Email = $"email{i}",
                        });
            }
            return list;
        }

    }
}
