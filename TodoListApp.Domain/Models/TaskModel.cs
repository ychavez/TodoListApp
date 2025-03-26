namespace TodoListApp.Domain.Models
{
    public class TaskModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
