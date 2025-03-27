using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces
{
    public interface ILabelTodoItemRepository
    {
        Task AddAssociation(LabelTodoItem item);
        Task RemoveAssociation(LabelTodoItem item);
        Task<IEnumerable<Label>> GetLabelsByTodoItem(LabelTodoItem item);
        Task<IEnumerable<TodoItem>> GetTodoItemsByLabel(LabelTodoItem item);
    }
}
