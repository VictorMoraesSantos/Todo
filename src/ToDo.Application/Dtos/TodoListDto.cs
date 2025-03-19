using ToDo.Domain.Enums;

namespace ToDo.Application.Dtos
{
    public record TodoListDto
    {
        public int Id { get; init; } = default!;
        public string ExternalId { get; init; } = default!;
        public string Title { get; init; } = default!;
        public string Description { get; init; } = default!;
        public TodoListStatus Status { get; init; }
        public bool IsFavorite { get; init; }
        public List<TodoItemDto> TodoItems { get; init; } = new();

        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }

        public TodoListDto(int id, string externalId, string title, string description, TodoListStatus status, bool isFavorite, List<TodoItemDto> todoItems, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            ExternalId = externalId;
            Title = title;
            Description = description;
            Status = status;
            IsFavorite = isFavorite;
            TodoItems = todoItems;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
