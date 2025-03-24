using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(TodoItem entity)
        {
            await _context.TodoItems.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem>? GetById(int id)
        {
            return await _context.TodoItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _context.TodoItems.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetByPriority(TodoItemPriority priority)
        {
            return await _context.TodoItems.AsNoTracking().Where(x => x.Priority == priority).ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetByStatus(TodoItemStatus status)
        {
            return await _context.TodoItems.AsNoTracking().Where(x => x.Status == status).ToListAsync();
        }

        public async Task Update(TodoItem entity)
        {
            _context.TodoItems.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TodoItem entity)
        {
            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
