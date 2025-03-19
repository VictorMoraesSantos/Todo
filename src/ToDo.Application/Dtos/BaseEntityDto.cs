namespace ToDo.Application.DTOs
{
    public record BaseEntityDto<T>
    {
        public BaseEntityDto(T id, string externalId, DateTime createdAt)
        {
            Id = id;
            ExternalId = externalId;
            CreatedAt = createdAt;
        }

        public T Id { get; init; } = default!;
        public string ExternalId { get; init; } = default!;
        public DateTime CreatedAt { get; init; }
    }
}
