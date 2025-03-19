using ToDo.Domain.Common;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities
{
    public class TodoItem : BaseEntity<int>
    {
        public string Title { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public DateTime? DueDate { get; private set; }
        public TodoItemPriority Priority { get; private set; }
        public TodoItemStatus Status { get; private set; }

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        private readonly List<LabelTodoItem> _labelTodoItems = new();
        public IReadOnlyCollection<LabelTodoItem> LabelTodoItems => _labelTodoItems.AsReadOnly();

        public int ListId { get; private set; }
        public TodoList List { get; private set; }

        protected TodoItem() { }

        public void CreateTodoItem(string title, string description, DateTime dueDate, TodoItemPriority priority, int listId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = TodoItemStatus.Pending;
            ListId = listId;
        }

        public void UpdateTodoItem(string? title, string? description, DateTime? dueDate, TodoItemPriority? priority, TodoItemStatus? status)
        {
            Title = title ?? Title;
            Description = description ?? Description;
            DueDate = dueDate ?? DueDate;
            Priority = priority ?? Priority;
            Status = status ?? Status;
            Updated();
        }

        public void MarkTodoItemAsCompleted()
        {
            Status = TodoItemStatus.Completed;
            Updated();
        }

        public void MarkAsCompleted()
        {
            Status = TodoItemStatus.Completed;
            Updated();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public void AddLabel(Label label)
        {
            _labelTodoItems.Add(new LabelTodoItem(label.Id, Id));
        }
    }
}