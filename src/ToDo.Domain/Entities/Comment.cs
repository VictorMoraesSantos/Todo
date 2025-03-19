using ToDo.Domain.Common;

namespace ToDo.Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public string Text { get; private set; }

        public int TodoItemId { get; private set; }
        public TodoItem TodoItem { get; private set; }

        protected Comment() { }
        public Comment(string text, int todoItemId)
        {
            Validate(text);
            Text = text;
            TodoItemId = todoItemId;
        }

        public void EditComment(string newText)
        {
            Text = newText;
            Updated();
        }
        public void DeleteComment()
        {
            Deleted();
        }

        private void Validate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be empty.", nameof(text));
        }
    }
}
