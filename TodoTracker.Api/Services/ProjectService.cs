using Microsoft.EntityFrameworkCore;
using TodoTracker.Api.Data;
using TodoTracker.Api.Models;

namespace TodoTracker.Api.Services;

public interface IProjectService
{
    IQueryable<TodoProject> GetProjects();
    
    Task<TodoProject?> GetProjectAsync(int id);
}

public class ProjectService : IAsyncDisposable, IProjectService
{
    private readonly TodoDbContext _dbContext;
    
    public ProjectService(IDbContextFactory<TodoDbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public IQueryable<TodoProject> GetProjects()
    {
        return _dbContext.Projects;
    }
    
    public async Task<TodoProject?> GetProjectAsync(int id)
    {
        return await _dbContext.Projects.FindAsync(id);
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }
}