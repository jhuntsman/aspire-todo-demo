namespace TodoTracker.Api.Models;

public class TodoProject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}