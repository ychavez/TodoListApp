namespace TodoListApp.Domain.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int Color { get; set; }
    }
}
