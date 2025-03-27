using ToDo.Domain.Enums;

namespace ToDo.Application.Dtos
{
    public record ReadTodoListDto(
        int Id,
        string ExternalId,
        DateTime CreatedAt,
        string Title,
        string Description,
        TodoListStatus Status,
        bool IsFavorite,
        int UserId,
        List<TodoItemDto>? TodoItems = null
    ) : BaseEntityDto<int>(Id, ExternalId, CreatedAt);
}
