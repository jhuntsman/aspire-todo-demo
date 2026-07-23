using MediatR;
using TodoTracker.Application.Models;
using TodoTracker.Application.Queries;

namespace TodoTracker.Api.Types;

[QueryType]
public static partial class Query
{
    [Query]
    public static async Task<IQueryable<TodoProject>> GetProjects(IMediator mediator, CancellationToken ct)
    {
        return await mediator.Send(new QueryProjects(), ct);
    }
    
    [Query]
    public static async Task<TodoProject?> GetProjectByIdAsync(int id, IMediator mediator, CancellationToken ct)
    {
        return await mediator.Send(new QueryProjectById(id), ct);
    }
}