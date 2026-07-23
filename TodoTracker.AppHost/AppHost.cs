var builder = DistributedApplication.CreateBuilder(args);

// Add Database support
var todo_db = builder
    .AddPostgres("pgsql")
        .WithDataVolume()
        .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin()
        .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("tododb");

// Add API project
builder.AddProject<Projects.TodoTracker_Api>("todo-api")
    .WithReference(todo_db);

builder.Build().Run();