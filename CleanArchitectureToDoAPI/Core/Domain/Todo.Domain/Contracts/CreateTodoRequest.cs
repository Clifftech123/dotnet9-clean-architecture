namespace Todo.Domain.Contracts
{
    public class CreateTodoRequest
    {
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public DateTime? DueDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public int TodoCategoryId { get; set; }

        public CreateTodoRequest()
        {
            IsDone = false;
        }
    }


}
