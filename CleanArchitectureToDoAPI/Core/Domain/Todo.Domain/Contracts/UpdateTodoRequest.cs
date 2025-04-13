namespace Todo.Domain.Contracts
{
    public class UpdateTodoRequest
    {
        public string? Title { get; set; }
        public bool? IsDone { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Note { get; set; }

    }
}
