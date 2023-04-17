global using FastEndpoints;
global using FluentValidation;

using ApiWithFastEndpoints.Database;
using ApiWithFastEndpoints.Services;
using FastEndpoints.Swagger;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(connectionString: builder.Configuration.GetConnectionString("Database")!));
builder.Services.AddTransient<MovieService>();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
    c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
app.UseSwaggerGen();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

app.Run();
