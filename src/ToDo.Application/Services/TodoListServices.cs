using ToDo.Application.DTOs;
using ToDo.Application.Interfaces;
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

        public Task AddAsync(TodoListDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TodoListDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoListDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsByUserIdAndArchivedAsync(int userId, bool isArchived)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsByUserIdAndFavoritedAsync(int userId, bool isFavorite)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsByUserIdAndStatusAsync(int userId, TodoListStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsSortedByDateAsync(int userId, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsThatContainsAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsThatContainsTaskWithAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsWithCompletedTasksAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetListsWithPendingTasksAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoListDto>> GetPaginatedListsAsync(int userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoListDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
