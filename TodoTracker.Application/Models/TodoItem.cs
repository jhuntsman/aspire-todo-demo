
namespace TodoTracker.Application.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }

    // Foreign Key to Project
    public int ProjectId { get; set; }
    public TodoProject Project { get; set; } = null!;

    // Many-to-Many with Tags
    public ICollection<TodoTag> Tags { get; set; } = new List<TodoTag>();
}