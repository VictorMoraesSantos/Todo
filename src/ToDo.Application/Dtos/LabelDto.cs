namespace ToDo.Application.Dtos
{
    public record LabelDto(
        int Id,
        string ExternalId,
        DateTime CreatedAt,
        string Name,
        string Color
    ) : BaseEntityDto<int>(Id, ExternalId, CreatedAt);
}
