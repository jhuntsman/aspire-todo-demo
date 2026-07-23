using TodoTracker.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddNpgsqlDbContext<TodoDbContext>("tododb");

builder.AddGraphQL()
    .RegisterDbContextFactory<TodoDbContext>()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);