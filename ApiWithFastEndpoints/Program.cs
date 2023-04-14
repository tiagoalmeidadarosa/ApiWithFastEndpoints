global using FastEndpoints;

using ApiWithFastEndpoints.Database;
using ApiWithFastEndpoints.Services;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(connectionString: builder.Configuration.GetConnectionString("Database")!));

builder.Services.AddTransient<MovieService>();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

app.Run();
