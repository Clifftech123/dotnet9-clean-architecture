namespace Todo.Application.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int Id) : base($"Category with id {Id} not found") { }
    }
}
