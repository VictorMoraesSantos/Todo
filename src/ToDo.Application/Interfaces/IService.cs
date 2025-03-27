using ToDo.Application.Dtos;

namespace ToDo.Application.Interfaces
{
    public interface IService<T>
        where T : BaseEntityDto<int>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface IService<TCreate, TRead>
        where TCreate : BaseEntityDto<int>
        where TRead : BaseEntityDto<int>
    {
        Task<TRead> GetByIdAsync(int id);
        Task<IEnumerable<TRead>> GetAllAsync();
        Task AddAsync(TCreate entity);
        Task UpdateAsync(TCreate entity);
        Task DeleteAsync(int id);
    }
}
