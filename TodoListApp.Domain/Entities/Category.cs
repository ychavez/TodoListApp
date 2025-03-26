namespace TodoListApp.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int Color { get; set; }
        public bool IsDeleted { get; set; }
    }
}
