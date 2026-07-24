using HotChocolate;

namespace TodoTracker.Application.Models;

[GraphQLDescription("Represents a todo project.")]
public class TodoProject
{
    [GraphQLDescription("The unique identifier of the todo project.")]
    public int Id { get; set; }
    
    [GraphQLDescription("The name of the todo project.")]
    public string Name { get; set; } = string.Empty;
    
    [GraphQLDescription("The collection of todo items associated with the todo project.")]
    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}