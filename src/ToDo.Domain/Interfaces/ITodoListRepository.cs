using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Interfaces
{
    public interface ITodoListRepository : IRepository<TodoList>
    {
        Task<IEnumerable<TodoList>> GetByStatusAsync(TodoListStatus status);
        Task<IEnumerable<TodoList>> GetFavoritesAsync(bool isFavorite);
    }
}
