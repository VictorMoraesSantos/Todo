using System.Text.Json.Serialization;

namespace ToDo.Application.Dtos
{
    public record BaseEntityDto<T>
    {
        public BaseEntityDto(T id, string externalId, DateTime createdAt)
        {
            Id = id;
            ExternalId = externalId;
            CreatedAt = createdAt;
        }
        [JsonPropertyOrder(-3)]
        public T Id { get; set; }
        [JsonPropertyOrder(-2)]
        public string ExternalId { get; init; } = default!;
        [JsonPropertyOrder(-1)]
        public DateTime CreatedAt { get; init; }
    }
}
