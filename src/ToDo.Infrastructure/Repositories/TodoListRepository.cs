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

        public async Task<TodoList> GetById(int id)
        {
            return await _context.TodoLists.AsNoTracking().Include(x => x.TodoItems).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TodoList>> GetAll()
        {
            return await _context.TodoLists.AsNoTracking().Include(x => x.TodoItems).ToListAsync();
        }

        public async Task Add(TodoList entity)
        {
            await _context.TodoLists.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TodoList entity)
        {
            _context.TodoLists.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TodoList entity)
        {
            _context.TodoLists.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoList>> GetByStatusAsync(TodoListStatus status)
        {
            return await _context.TodoLists.AsNoTracking().Include(x => x.TodoItems).Where(x => x.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<TodoList>> GetFavoritesAsync(bool isFavorite)
        {
            return await _context.TodoLists.AsNoTracking().Include(x => x.TodoItems).Where(x => x.IsFavorite == isFavorite).ToListAsync();
        }
    }
}
