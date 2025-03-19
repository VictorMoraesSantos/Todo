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

        public async Task<TodoList> GetById(int id)
        {
            return await _context.TodoLists.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TodoList>> GetListsByUserId(int userId)
        {
            return await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsByUserIdAndArchived(int userId, bool isArchived)
        {
            return await _context.TodoLists.AsNoTracking()
                .Where(x => x.UserId == userId && (isArchived ? x.Status == TodoListStatus.Archived : x.Status != TodoListStatus.Archived))
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsByUserIdAndFavorited(int userId, bool isFavorite)
        {
            return await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId && x.IsFavorite == isFavorite).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsByUserIdAndStatus(int userId, TodoListStatus status)
        {
            return await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId && x.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsSortedByDate(int userId, bool ascending = true)
        {
            return ascending
                ? await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId).OrderBy(x => x.CreatedAt).ToListAsync()
                : await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsThatContains(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<TodoList>();

            return await _context.TodoLists.AsNoTracking()
                .Where(x => EF.Functions.Like(x.Title, $"%{keyword}%") || EF.Functions.Like(x.Description, $"%{keyword}%"))
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsThatContainsTaskWith(string keyword)
        {
            return await _context.TodoLists.AsNoTracking().Where(x => x.TodoItems.Any(ti => ti.Title.Contains(keyword) || ti.Description.Contains(keyword))).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsWithCompletedTasks(int userId)
        {
            return await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId && x.TodoItems.Any(ti => ti.Status == TodoItemStatus.Completed)).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetListsWithPendingTasks(int userId)
        {
            return await _context.TodoLists.AsNoTracking().Where(x => x.UserId == userId && x.TodoItems.Any(ti => ti.Status == TodoItemStatus.Pending)).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetPaginatedLists(int userId, int pageNumber = 1, int pageSize = 10)
        {
            return await _context.TodoLists.AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Update(TodoList entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
