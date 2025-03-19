namespace ToDo.Domain.Entities
{
    public class LabelTodoItem
    {
        public int LabelId { get; private set; }
        public Label Label { get; private set; }

        public int TodoItemId { get; private set; }
        public TodoItem TodoItem { get; private set; }

        protected LabelTodoItem() { } // Necessário para EF Core

        public LabelTodoItem(int todoItemId, int labelId)
        {
            TodoItemId = todoItemId;
            LabelId = labelId;
        }
    }
}
