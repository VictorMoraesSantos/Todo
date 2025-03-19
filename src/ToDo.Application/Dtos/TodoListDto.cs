using ToDo.Application.Dtos;
using ToDo.Domain.Enums;

namespace ToDo.Application.DTOs
{
    public record TodoListDto : BaseEntityDto<int>
    {
        public TodoListDto(int id, string externalId, DateTime createdAt, string title, string description, TodoListStatus status, bool isFavorite, int userId, List<TodoItemDto> todoItems)
            : base(id, externalId, createdAt)
        {
            Title = title;
            Description = description;
            Status = status;
            IsFavorite = isFavorite;
            UserId = userId;
            TodoItems = todoItems;
        }

        public string Title { get; init; } = default!;
        public string Description { get; init; } = default!;
        public TodoListStatus Status { get; init; }
        public bool IsFavorite { get; init; }
        public int UserId { get; init; }
        public List<TodoItemDto> TodoItems { get; init; } = new();
    }
}
