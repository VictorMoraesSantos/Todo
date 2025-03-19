using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; } = default!;
        public string ExternalId { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public void Updated() => UpdatedAt = DateTime.Now;
        public void Deleted()
        {
            DeletedAt = DateTime.Now;
            IsDeleted = true;
            Updated();
        }
    }
}
