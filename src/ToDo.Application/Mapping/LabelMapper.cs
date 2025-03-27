using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Mapping
{
    public static class LabelMapper
    {
        public static LabelDto ToDto(Label label)
        {
            return new LabelDto(
                label.Id,
                label.ExternalId,
                label.CreatedAt,
                label.Name,
                label.Color
            );
        }

        public static Label ToEntity(LabelDto dto)
        {
            Label label = new Label(dto.Name, dto.Color);
            return label;
        }
    }
}
