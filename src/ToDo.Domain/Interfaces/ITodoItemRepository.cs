using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Interfaces
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetByPriority(TodoItemPriority priority);
        Task<IEnumerable<TodoItem>> GetByStatus(TodoItemStatus status);

        Task<IEnumerable<Comment>> GetComments(int todoItemId);
        Task<Comment> GetComment(int todoItemId, int commentId);
        Task AddComment(int todoItemId, Comment comment);
        Task EditComment(int todoItemId, Comment comment);
        Task DeleteComment(int todoItemId, int commentId);
    }
}
