using Microsoft.EntityFrameworkCore;
using TodoTracker.Api.Models;

namespace TodoTracker.Api.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<TodoTag> Tags => Set<TodoTag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoTag>()
            .ToTable("Tags");
        
        modelBuilder.Entity<TodoItem>()
            .HasMany(t => t.Tags)
            .WithMany(tag => tag.TodoItems)
            .UsingEntity(j => j.ToTable("TodoItemTags"));
    }
}