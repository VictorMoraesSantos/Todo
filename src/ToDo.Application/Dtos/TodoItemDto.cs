using ToDo.Domain.Enums;

namespace ToDo.Application.Dtos
{
    public record TodoItemDto(
        int Id,
        string ExternalId,
        DateTime CreatedAt,
        string Title,
        string Description,
        DateTime? DueDate,
        TodoItemPriority Priority,
        TodoItemStatus Status,
        int ListId
    ) : BaseEntityDto<int>(Id, ExternalId, CreatedAt);
}
