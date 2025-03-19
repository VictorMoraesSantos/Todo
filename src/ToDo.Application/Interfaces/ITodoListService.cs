using ToDo.Application.DTOs;
using ToDo.Domain.Enums;

namespace ToDo.Application.Interfaces
{
    public interface ITodoListService : IService<TodoListDto>
    {
        Task<IEnumerable<TodoListDto>> GetListsByUserIdAsync(int userId);
        Task<IEnumerable<TodoListDto>> GetListsByUserIdAndStatusAsync(int userId, TodoListStatus status);
        Task<IEnumerable<TodoListDto>> GetListsByUserIdAndArchivedAsync(int userId, bool isArchived);
        Task<IEnumerable<TodoListDto>> GetListsByUserIdAndFavoritedAsync(int userId, bool isFavorite);
        Task<IEnumerable<TodoListDto>> GetListsThatContainsAsync(string keyword);
        Task<IEnumerable<TodoListDto>> GetListsThatContainsTaskWithAsync(string keyword);
        Task<IEnumerable<TodoListDto>> GetListsWithCompletedTasksAsync(int userId);
        Task<IEnumerable<TodoListDto>> GetListsWithPendingTasksAsync(int userId);
        Task<IEnumerable<TodoListDto>> GetPaginatedListsAsync(int userId, int pageNumber, int pageSize);
        Task<IEnumerable<TodoListDto>> GetListsSortedByDateAsync(int userId, bool ascending = true);
    }
}
