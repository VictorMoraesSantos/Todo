using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Interfaces
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetByPriority(TodoItemPriority priority);
        Task<IEnumerable<TodoItem>> GetByStatus(TodoItemStatus status);
    }
}
