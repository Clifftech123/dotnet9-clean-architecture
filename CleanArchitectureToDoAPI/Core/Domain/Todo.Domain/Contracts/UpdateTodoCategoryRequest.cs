namespace Todo.Domain.Contracts
{
    public class UpdateTodoCategoryRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
