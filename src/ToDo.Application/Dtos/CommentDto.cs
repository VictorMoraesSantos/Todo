namespace ToDo.Application.Dtos
{
    public record CommentDto(
        int Id,
        string ExternalId,
        DateTime CreatedAt,
        string Text,
        int TodoItemId)
        : BaseEntityDto<int>(Id, ExternalId, CreatedAt);
}
