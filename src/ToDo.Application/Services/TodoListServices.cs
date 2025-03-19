using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Services
{
    public class TodoListServices : ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListServices(ITodoListRepository todoListRepository)
        {
            todoListRepository = _todoListRepository;
        }

        public Task AddAsync(TodoList entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TodoList entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoList> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsByUserIdAndArchivedAsync(int userId, bool isArchived)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsByUserIdAndFavoritedAsync(int userId, bool isFavorite)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsByUserIdAndStatusAsync(int userId, TodoListStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsSortedByDateAsync(int userId, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsThatContainsAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsThatContainsTaskWithAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsWithCompletedTasksAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsWithPendingTasksAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetPaginatedListsAsync(int userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoList entity)
        {
            throw new NotImplementedException();
        }
    }
}
