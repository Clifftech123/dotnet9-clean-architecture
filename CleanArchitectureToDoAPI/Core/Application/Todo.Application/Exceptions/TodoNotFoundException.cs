namespace Todo.Application.Exceptions
{
    public class TodoNotFoundException : NotFoundException
    {
        public TodoNotFoundException(int Id) : base($"Todo with id {Id} not found") { }
    }
}
