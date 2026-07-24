using Microsoft.EntityFrameworkCore;
using TodoTracker.Api.Data;
using TodoTracker.Application.Models;

namespace TodoTracker.Api.Types;


[ObjectType]
public class TodoProjectType : ObjectType<TodoProject>
{
    protected override void Configure(IObjectTypeDescriptor<TodoProject> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(x => x.Id)
            .IsProjected();
        
        descriptor.Field("todoItemsCount")
            .Description("The number of todo items in the project")
            .Type<NonNullType<IntType>>()
            .ParentRequires<TodoProject>(p => p.Id)
            .Resolve(async (ctx, ct) =>
            {
                var parent = ctx.Parent<TodoProject>();
                var dbContextFactory = ctx.Service<IDbContextFactory<TodoDbContext>>();
                await using var dbContext = await dbContextFactory.CreateDbContextAsync(ct);
                
                return await dbContext.TodoItems.CountAsync(x=> x.ProjectId == parent.Id, ct);
            });
            
    }
}