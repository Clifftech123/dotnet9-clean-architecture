namespace Todo.Application.Exceptions
{
    public class RepositoryException(string message, Exception innerException) : Exception(
       message, innerException
        )
    {
    }
}
