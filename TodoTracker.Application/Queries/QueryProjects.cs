using MediatR;
using TodoTracker.Application.Interfaces;
using TodoTracker.Application.Models;

namespace TodoTracker.Application.Queries;

public record QueryProjects : IRequest<IQueryable<TodoProject>>
{
    
}

public class QueryProjectsRequestHandler : IRequestHandler<QueryProjects, IQueryable<TodoProject>>
{
    private readonly IProjectService _projectService;

    public QueryProjectsRequestHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    public Task<IQueryable<TodoProject>> Handle(QueryProjects request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_projectService.GetProjects());
    }
}