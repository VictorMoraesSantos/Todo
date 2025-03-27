using ToDo.Application.Dtos;
using ToDo.Domain.Enums;

namespace ToDo.Application.Interfaces
{
    public interface ITodoListService : IService<CreateTodoListDto, ReadTodoListDto>
    {
        Task MarkAsActiveAsync(int id);
        Task MarkAsFavoriteAsync(int id);
        Task UnmarkAsFavoriteAsync(int id);
        Task MarkAsArchivedAsync(int id);
        Task MarkAsDeletedAsync(int id);
        Task<IEnumerable<ReadTodoListDto>> GetByStatusAsync(TodoListStatus status);
        Task<IEnumerable<ReadTodoListDto>> GetFavoritesAsync(bool favorited = true);
    }
}
