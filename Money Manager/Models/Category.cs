namespace Money_Manager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category Children { get; set; }
        public Category Parent { get; set; }
        public CategoryType Type { get; set; }
    }
}
