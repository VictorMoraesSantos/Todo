using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly ApplicationDbContext _context;

        public LabelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Label> GetById(int id)
        {
            return _context.Labels.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Label>> GetAll()
        {
            return await _context.Labels.AsNoTracking().ToListAsync();
        }

        public async Task Add(Label entity)
        {
            await _context.Labels.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Label entity)
        {
            _context.Labels.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Label entity)
        {
            _context.Labels.Remove(entity);
            await _context.SaveChangesAsync();

        }
    }
}
