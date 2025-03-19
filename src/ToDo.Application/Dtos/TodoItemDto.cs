using ToDo.Application.DTOs;
using ToDo.Domain.Enums;

namespace ToDo.Application.Dtos
{
    public record TodoItemDto : BaseEntityDto<int>
    {
        public TodoItemDto(int id, string externalId, DateTime createdAt, string title, string description, DateTime? dueDate, TodoItemPriority priority, TodoItemStatus status, int listId)
            : base(id, externalId, createdAt)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
            ListId = listId;
        }

        public string Title { get; init; } = default!;
        public string Description { get; init; } = default!;
        public DateTime? DueDate { get; init; }
        public TodoItemPriority Priority { get; init; }
        public TodoItemStatus Status { get; init; }
        public int ListId { get; init; }
    }
}
