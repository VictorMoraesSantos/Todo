using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(TodoList entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TodoList entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoList>> GetAll()
        {
            return await _context.TodoLists.AsNoTracking().ToListAsync();
        }

        public async Task<TodoList>? GetById(int id)
        {
            return await _context.TodoLists.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TodoList>> GetListsByUserId(int userId)
        {
            return await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public Task<IEnumerable<TodoList>> GetListsByUserIdAndArchived(int userId, bool isArchived)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsByUserIdAndFavorited(int userId, bool isFavorite)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsByUserIdAndStatus(int userId, TodoListStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsSortedByDate(int userId, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsThatContains(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsThatContainsTaskWith(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsWithCompletedTasks(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetListsWithPendingTasks(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> GetPaginatedLists(int userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task Update(TodoList entity)
        {
            throw new NotImplementedException();
        }
    }
}
