using HotChocolate.Diagnostics;
using OpenTelemetry.Trace;
using TodoTracker.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Aspire defaults
builder.AddServiceDefaults(tracing =>
{
    // add instrumentation specific for GraphQL service
    tracing.AddHotChocolateInstrumentation();
});

// Add Entity Framework support
builder.AddNpgsqlDbContext<TodoDbContext>("tododb");
builder.EnrichNpgsqlDbContext<TodoDbContext>();
builder.Services.AddPooledDbContextFactory<TodoDbContext>(cfg =>
{
    if (builder.Environment.IsDevelopment())
    {
        cfg.EnableDetailedErrors();
        cfg.EnableSensitiveDataLogging();
    }
});

// Add GraphQL support
builder.AddGraphQL()
    .RegisterDbContextFactory<TodoDbContext>()
    .AddInstrumentation(options =>
    {
        options.Scopes = ActivityScopes.All;
        options.IncludeDocument = true;
    })
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);