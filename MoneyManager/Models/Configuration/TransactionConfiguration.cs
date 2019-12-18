using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoneyManager.Models
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData(CreateTransactions());
        }

        IEnumerable<object> CreateTransactions()
        {
            List<object> list = new List<object>();
            var counter = 1;
            for (int k = 0; k < 10; k++)
            {
                for (var i = 1; i <= 10; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        list.Add(
                            new
                            {
                                TransactionId = counter,
                                Amount = new decimal(counter * 10),
                                UserId = i,
                                CategoryId = i,
                                AssetId = i,
                                Date = DateTime.Now.AddDays(-counter * 5)
                            }
                        );
                        counter++;

                        list.Add(
                            new
                            {
                                TransactionId = counter,
                                Amount = new decimal((counter - 1) * 10),
                                UserId = i,
                                CategoryId = i + 3 + j,
                                AssetId = i + 1,
                                Date = DateTime.Now.AddDays(-counter * 5)
                            }
                        );
                        counter++;
                    }
                }
            }

            return list;

        }
    }

}
