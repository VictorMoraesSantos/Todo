using ToDo.Domain.Enums;

namespace ToDo.Application.Dtos
{
    public record CreateTodoListDto(int Id,
        string ExternalId,
        DateTime CreatedAt,
        string Title,
        string Description,
        TodoListStatus Status,
        bool IsFavorite,
        int UserId)
        : BaseEntityDto<int>(Id, ExternalId, CreatedAt);

}
