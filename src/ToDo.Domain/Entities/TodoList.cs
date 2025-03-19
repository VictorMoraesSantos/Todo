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
        public List<TodoItem> TodoItems { get; private set; } = new();

        public TodoList() { }

        public void CreateTodoList(string title, string description, List<TodoItem> todoItems)
        {
            Title = title;
            Description = description;
            Status = TodoListStatus.Active;
            TodoItems = todoItems ?? new List<TodoItem>();
        }

        public void UpdateTodoList(string? title, string? description, TodoListStatus? status, List<TodoItem>? todoItems)
        {
            Title = title ?? Title;
            Description = description ?? Description;
            Status = status ?? Status;
            TodoItems = todoItems ?? TodoItems;
            Updated();
        }
        public void ArchiveTodoList()
        {
            Status = TodoListStatus.Archived;
            Updated();
        }

        public void MarkAsFavorite()
        {
            IsFavorite = true;
            Updated();
        }
    }
}

