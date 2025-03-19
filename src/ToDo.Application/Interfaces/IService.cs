using ToDo.Domain.Common;
using ToDo.Domain.Entities;

namespace ToDo.Application.Interfaces
{
    public interface IService<T> where T : BaseEntity<int>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
