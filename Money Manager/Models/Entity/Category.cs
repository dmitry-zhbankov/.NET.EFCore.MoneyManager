using System.Collections.Generic;

namespace Money_Manager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Children { get; set; }

        public Category Parent { get; set; }

        public CategoryType Type { get; set; }
    }
}
