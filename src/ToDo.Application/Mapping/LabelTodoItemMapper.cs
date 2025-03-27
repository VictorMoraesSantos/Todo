using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Mapping
{
    public static class LabelTodoItemMapper
    {
        public static LabelTodoItemDto ToDto(LabelTodoItem entity)
        {
            LabelTodoItemDto dto = new LabelTodoItemDto(
                entity.TodoItemId,
                entity.LabelId
            );
            return dto;
        }

        public static LabelTodoItem ToEntity(LabelTodoItemDto dto)
        {
            LabelTodoItem entity = new LabelTodoItem(dto.TodoItemId, dto.LabelId);
            return entity;
        }
    }
}
