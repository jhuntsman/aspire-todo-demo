using MediatR;
using TodoTracker.Application.Commands;
using TodoTracker.Application.Models;

namespace TodoTracker.Api.Types;

[MutationType]
public static partial class Mutation
{
    [Mutation]
    public static async Task<TodoProject> ProjectNew(ProjectNewInput input, IMediator mediator)
    {
        return await mediator.Send(new ProjectNewCommand(new TodoProject { Name = input.Name }));
    }
}