using ToDo.Domain.Common;

namespace ToDo.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity<int>
    {
        Task<T>? GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
