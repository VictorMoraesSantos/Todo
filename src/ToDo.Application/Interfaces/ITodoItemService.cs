using ToDo.Application.Dtos;
using ToDo.Domain.Enums;

namespace ToDo.Application.Interfaces
{
    public interface ITodoItemService : IService<TodoItemDto>
    {
        Task SetStatusAsync(int id, TodoItemStatus status);
        Task<IEnumerable<TodoItemDto>> GetByStatusAsync(TodoItemStatus status);

        Task SetPriorityAsync(int id, TodoItemPriority priority);
        Task<IEnumerable<TodoItemDto>> GetByPriorityAsync(TodoItemPriority priority);

        Task<IEnumerable<CommentDto>> GetCommentsAsync(int todoItemId);
        Task<CommentDto> GetCommentAsync(int todoItemId, int commentId);
        Task AddCommentAsync(int todoItemId, CommentDto commentDto);
        Task EditCommentAsync(int todoItemId, CommentDto commentDto);
        Task DeleteCommentAsync(int todoItemId, int commentId);
    }
}
