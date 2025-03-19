using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Interfaces
{
    public interface ITodoListRepository : IRepository<TodoList>
    {
        Task<IEnumerable<TodoList>> GetListsByUserId(int userId);
        Task<IEnumerable<TodoList>> GetListsByUserIdAndStatus(int userId, TodoListStatus status);
        Task<IEnumerable<TodoList>> GetListsByUserIdAndArchived(int userId, bool isArchived);
        Task<IEnumerable<TodoList>> GetListsByUserIdAndFavorited(int userId, bool isFavorite);
        Task<IEnumerable<TodoList>> GetListsThatContains(string keyword);
        Task<IEnumerable<TodoList>> GetListsThatContainsTaskWith(string keyword);
        Task<IEnumerable<TodoList>> GetListsWithCompletedTasks(int userId);
        Task<IEnumerable<TodoList>> GetListsWithPendingTasks(int userId);
        Task<IEnumerable<TodoList>> GetPaginatedLists(int userId, int pageNumber, int pageSize);
        Task<IEnumerable<TodoList>> GetListsSortedByDate(int userId, bool ascending = true);
    }
}
