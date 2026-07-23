using MediatR;
using TodoTracker.Application.Interfaces;
using TodoTracker.Application.Models;

namespace TodoTracker.Application.Queries;

public record QueryProjectById(int ProjectId) : IRequest<TodoProject?>
{
    
}

public class QueryProjectsByIdRequestHandler : IRequestHandler<QueryProjectById, TodoProject?>
{
    private readonly IProjectService _projectService;

    public QueryProjectsByIdRequestHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    public async Task<TodoProject?> Handle(QueryProjectById request, CancellationToken cancellationToken)
    {
        return await _projectService.GetProjectAsync(request.ProjectId);
    }
}