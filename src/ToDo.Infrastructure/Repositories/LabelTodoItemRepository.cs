using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories
{
    public class LabelTodoItemRepository : ILabelTodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public LabelTodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAssociation(LabelTodoItem item)
        {
            await _context.Set<LabelTodoItem>().AddAsync(new LabelTodoItem(item.TodoItemId, item.LabelId));
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAssociation(LabelTodoItem item)
        {
            _context.Set<LabelTodoItem>().Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Label>> GetLabelsByTodoItem(LabelTodoItem item)
        {
            return await _context.Set<LabelTodoItem>()
                .Where(x => x.TodoItemId == item.TodoItemId)
                .Select(x => x.Label)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsByLabel(LabelTodoItem item)
        {
            return await _context.Set<LabelTodoItem>()
                .Include(x => x.TodoItem)
                .ThenInclude(ti => ti.LabelTodoItems)
                .ThenInclude(lti => lti.Label)
                .Where(x => x.LabelId == item.LabelId)
                .Select(x => x.TodoItem)
                .ToListAsync();

        }
    }
}
