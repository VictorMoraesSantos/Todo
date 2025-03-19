using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Application.Interfaces
{
    public interface ITodoListService : IService<TodoList>
    {
        Task<IEnumerable<TodoList>> GetListsByUserIdAsync(int userId);
        Task<IEnumerable<TodoList>> GetListsByUserIdAndStatusAsync(int userId, TodoListStatus status);
        Task<IEnumerable<TodoList>> GetListsByUserIdAndArchivedAsync(int userId, bool isArchived);
        Task<IEnumerable<TodoList>> GetListsByUserIdAndFavoritedAsync(int userId, bool isFavorite);
        Task<IEnumerable<TodoList>> GetListsThatContainsAsync(string keyword);
        Task<IEnumerable<TodoList>> GetListsThatContainsTaskWithAsync(string keyword);
        Task<IEnumerable<TodoList>> GetListsWithCompletedTasksAsync(int userId);
        Task<IEnumerable<TodoList>> GetListsWithPendingTasksAsync(int userId);
        Task<IEnumerable<TodoList>> GetPaginatedListsAsync(int userId, int pageNumber, int pageSize);
        Task<IEnumerable<TodoList>> GetListsSortedByDateAsync(int userId, bool ascending = true);
    }
}
