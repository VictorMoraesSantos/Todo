using ToDo.Domain.Common;
using ToDo.Domain.Exceptions;

namespace ToDo.Domain.Entities
{
    public class Label : BaseEntity<int>
    {
        public string Name { get; private set; } = default!;
        public string Color { get; private set; } = default!;

        protected Label() { }

        public Label(string name, string color)
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
                throw new DomainException("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(color))
                throw new DomainException("Color cannot be empty.");
        }
    }
}
