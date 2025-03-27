using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Interfaces
{
    public interface ILabelService : IService<LabelDto>
    {
        Task AddAssociationAsync(LabelTodoItemDto item);
        Task RemoveAssociationAsync(LabelTodoItemDto item);
        Task<IEnumerable<LabelDto>> GetLabelsByTodoItemAsync(LabelTodoItemDto item);
        Task<IEnumerable<TodoItemDto>> GetTodoItemsByLabelAsync(LabelTodoItemDto item);
    }
}
