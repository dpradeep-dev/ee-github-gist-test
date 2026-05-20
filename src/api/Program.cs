using System.Text.Json;

using Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddHttpClient<GitHubService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.MapGet("/{username}", async (string username, GitHubService service) =>
{
    var gists = await service.GetPublicGists(username);
    return gists is null || !gists.Any() ? Results.NotFound() : Results.Ok(gists);
});

app.Run();
