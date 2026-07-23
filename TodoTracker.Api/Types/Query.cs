using TodoTracker.Api.Data;
using TodoTracker.Api.Models;
using TodoTracker.Api.Services;

namespace TodoTracker.Api.Types;

[QueryType]
public static partial class Query
{
    [Query]
    public static IQueryable<TodoProject> GetProjects(TodoDbContext dbContext)
    {
        return dbContext.Projects;
    }
    
    [Query]
    public static async Task<TodoProject?> GetProjectByIdAsync(int id, IProjectService projectService)
    {
        return await projectService.GetProjectAsync(id);
    }
}