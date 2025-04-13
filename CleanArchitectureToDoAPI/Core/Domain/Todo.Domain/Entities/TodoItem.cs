namespace Todo.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public DateTime? DueDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public int TodoCategoryId { get; set; }
        public TodoCategory Category { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
