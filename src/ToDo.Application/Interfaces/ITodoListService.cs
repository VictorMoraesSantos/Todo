using ToDo.Application.Dtos;
using ToDo.Domain.Enums;

namespace ToDo.Application.Interfaces
{
    public interface ITodoListService : IService<TodoListDto>
    {
        Task MarkAsActiveAsync(int id);
        Task MarkAsFavoriteAsync(int id);
        Task UnmarkAsFavoriteAsync(int id);
        Task MarkAsArchivedAsync(int id);
        Task MarkAsDeletedAsync(int id);
        Task<IEnumerable<TodoListDto>> GetByStatusAsync(TodoListStatus status);
        Task<IEnumerable<TodoListDto>> GetFavoritesAsync(bool favorited = true);
    }
}
