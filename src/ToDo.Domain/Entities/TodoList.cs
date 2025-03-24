using ToDo.Domain.Common;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities
{
    public class TodoList : BaseEntity<int>
    {
        public string Title { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public TodoListStatus Status { get; private set; }
        public bool IsFavorite { get; private set; }
        public int UserId { get; private set; } = default!;
        private readonly List<TodoItem> _todoItems = new();
        public IReadOnlyCollection<TodoItem> TodoItems => _todoItems.AsReadOnly();

        public TodoList() { }

        public TodoList(string title, string description, int userId, List<TodoItem>? todoItems)
        {
            Title = title;
            Description = description;
            UserId = userId;
            Status = TodoListStatus.Active;
            _todoItems = todoItems;
        }

        public void UpdateList(string? title, string? description)
        {
            Title = title ?? Title;
            Description = description ?? Description;
            Updated();
        }

        public void AddTodoItem(TodoItem item)
        {
            _todoItems.Add(item);
            Updated();
        }

        public void MarkAsActive()
        {
            Status = TodoListStatus.Active;
            Updated();
        }

        public void MarkAsArchived()
        {
            Status = TodoListStatus.Archived;
            Updated();
        }

        public void MarkAsDeleted()
        {
            Status = TodoListStatus.Deleted;
            Deleted();
        }

        public void MarkAsFavorite()
        {
            IsFavorite = true;
            Updated();
        }

        public void UnmarkAsFavorite()
        {
            IsFavorite = false;
            Updated();
        }
    }
}

