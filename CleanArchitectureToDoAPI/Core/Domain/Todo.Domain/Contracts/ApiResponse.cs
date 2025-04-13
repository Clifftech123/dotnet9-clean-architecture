namespace Todo.Domain.Contracts
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = new object();

    }
}
