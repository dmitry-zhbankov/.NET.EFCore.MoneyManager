using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MoneyManager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Category> Children { get; set; }

        public Category Parent { get; set; }

        [Required]
        public CategoryType Type { get; set; }

        public IEnumerable<UserCategory> UserCategories { get; set; }

        public Category()
        {
            Children = new List<Category>();
        }
    }
}