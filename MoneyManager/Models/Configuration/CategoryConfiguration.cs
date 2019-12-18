using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoneyManager.Models
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());

        }

        IEnumerable<object> CreateCategories()
        {
            List<object> list = new List<object>();
            var counter = 1;
            for (var i = 1; i <= 10; i++)
            {
                list.Add(
                    new
                    {
                        CategoryId = counter,
                        Name = $"Category{i}Income",
                        Type = CategoryType.Income
                    }
                );
                counter++;
                list.Add(
                    new
                    {
                        CategoryId = counter,
                        Name = $"Category{i}1Income",
                        Type = CategoryType.Income,
                        ParentCategoryId = counter - 1
                    }
                );
                counter++;
                list.Add(
                    new
                    {
                        CategoryId = counter,
                        Name = $"Category{i}2Income",
                        Type = CategoryType.Income,
                        ParentCategoryId = counter - 2
                    }
                );
                counter++;

                list.Add(
                    new
                    {
                        CategoryId = counter,
                        Name = $"Category{i}Expense",
                        Type = CategoryType.Expense
                    }
                );
                counter++;
                list.Add(
                    new
                    {
                        CategoryId = counter,
                        Name = $"Category{i}1Expense",
                        Type = CategoryType.Expense,
                        ParentCategoryId = counter - 1
                    }
                );
                counter++;
                list.Add(
                    new
                    {
                        CategoryId = counter,
                        Name = $"Category{i}2Expense",
                        Type = CategoryType.Expense,
                        ParentCategoryId = counter - 2
                    }
                );
                counter++;

            }

            return list;

        }
    }

}
