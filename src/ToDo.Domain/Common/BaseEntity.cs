using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; } = default!;
        public string ExternalId { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void Updated() => UpdatedAt = DateTime.UtcNow;
        public void Deleted()
        {
            DeletedAt = DateTime.UtcNow;
            IsDeleted = true;
            Updated();
        }
    }
}
