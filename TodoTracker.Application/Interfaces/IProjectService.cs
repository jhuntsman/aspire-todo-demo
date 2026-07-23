using TodoTracker.Application.Models;

namespace TodoTracker.Application.Interfaces;

public interface IProjectService
{
    IQueryable<TodoProject> GetProjects();
    
    Task<TodoProject?> GetProjectAsync(int id);
    Task<TodoProject> AddProject(TodoProject project);
}