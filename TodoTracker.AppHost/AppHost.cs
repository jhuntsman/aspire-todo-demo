var builder = DistributedApplication.CreateBuilder(args);

// Add Database support
builder
    .AddPostgres("pgsql")
        .WithDataVolume()
        .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin()
        .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("tododb");

builder.Build().Run();