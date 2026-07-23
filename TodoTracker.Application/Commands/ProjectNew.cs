using MediatR;
using TodoTracker.Application.Interfaces;
using TodoTracker.Application.Models;

namespace TodoTracker.Application.Commands;

public record ProjectNewCommand(TodoProject Model) : IRequest<TodoProject>
{

}

public class ProjectNewCommandHandler : IRequestHandler<ProjectNewCommand, TodoProject>
{
    private readonly IProjectService _projectService;

    public ProjectNewCommandHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    public async Task<TodoProject> Handle(ProjectNewCommand request, CancellationToken cancellationToken)
    {
        return await _projectService.AddProject(request.Model);
    }
}