namespace Todo.Domain.Entities
{
     public class TodoCategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}
