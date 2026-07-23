using Microsoft.EntityFrameworkCore;
using TodoTracker.Api.Data;
using TodoTracker.Application.Interfaces;
using TodoTracker.Application.Models;

namespace TodoTracker.Api.Services;

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