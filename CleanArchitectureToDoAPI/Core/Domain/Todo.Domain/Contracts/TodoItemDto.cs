using System.Text.Json.Serialization;

namespace Todo.Domain.Contracts
{
     public class TodoItemDto
    {
        [JsonIgnore]
        public bool IsUpdateOperation { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime? DueDate { get; set; }
        public string Note { get; set; }
        public int TodoCategoryId { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
