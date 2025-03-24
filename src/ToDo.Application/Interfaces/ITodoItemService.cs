using ToDo.Application.Dtos;
using ToDo.Domain.Enums;

namespace ToDo.Application.Interfaces
{
    public interface ITodoItemService : IService<TodoItemDto>
    {
        Task SetStatusAsync(int id, TodoItemStatus status);
        Task<IEnumerable<TodoItemDto>> GetByStatusAsync(TodoItemStatus status);

        Task SetPriorityAsync(int id, TodoItemPriority priority);
        Task<IEnumerable<TodoItemDto>> GetByPriorityAsync(TodoItemPriority priority);
    }
}
