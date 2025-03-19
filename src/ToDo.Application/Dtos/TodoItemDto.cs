using ToDo.Domain.Enums;

namespace ToDo.Application.Dtos
{
    public record TodoItemDto
    {
        public int Id { get; init; } = default!;
        public string ExternalId { get; init; } = default!;
        public string Title { get; init; } = default!;
        public string Description { get; init; } = default!;
        public DateTime? DueDate { get; init; }
        public TodoItemPriority Priority { get; init; }
        public TodoItemStatus Status { get; init; }
        //public List<CommentDto> Comments { get; init; } = new();
        public int ListId { get; init; }

        public TodoItemDto(int id, string externalId, string title, string description, DateTime? dueDate, TodoItemPriority priority, TodoItemStatus status, int listId)
        {
            Id = id;
            ExternalId = externalId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
            ListId = listId;
        }
    }
}
