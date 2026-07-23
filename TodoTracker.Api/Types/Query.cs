using TodoTracker.Api.Data;
using TodoTracker.Api.Models;

namespace TodoTracker.Api.Types;

[QueryType]
public static partial class Query
{
    [Query]
    public static IQueryable<TodoProject> GetProjects(TodoDbContext dbContext)
    {
        return dbContext.Projects;
    }
}