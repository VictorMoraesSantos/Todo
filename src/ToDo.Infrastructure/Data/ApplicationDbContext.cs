using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabelTodoItem>()
                .HasKey(lt => new { lt.LabelId, lt.TodoItemId });

            modelBuilder.Entity<LabelTodoItem>()
                .HasOne(lt => lt.Label)
                .WithMany()
                .HasForeignKey(lt => lt.LabelId);

            modelBuilder.Entity<LabelTodoItem>()
                .HasOne(lt => lt.TodoItem)
                .WithMany(ti => ti.LabelTodoItems)
                .HasForeignKey(lt => lt.TodoItemId);
        }

    }
}
