using ToDo.Domain.Common;

namespace ToDo.Domain.Entities
{
    public class Label : BaseEntity<int>
    {
        public string Name { get; private set; } = default!;
        public string Color { get; private set; } = default!;

        protected Label() { }

        public void CreateLabel(string name, string color)
        {
            Validate(name, color);
            Name = name;
            Color = color;
        }
        public void EditLabel(string? name, string? color)
        {
            Validate(name, color);
            Name = name ?? Name;
            Color = color ?? Color;
            Updated();
        }
        public void DeleteLabel()
        {
            IsDeleted = true;
        }

        private void Validate(string name, string color)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentException("Color cannot be empty.", nameof(color));
        }
    }
}
