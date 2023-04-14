using ApiWithFastEndpoints.Database;
using ApiWithFastEndpoints.Entities;
using ApiWithFastEndpoints.Models.Responses;
using Dapper;

namespace ApiWithFastEndpoints.Services;

public class MovieService
{
    private readonly IDbConnectionFactory _connectionFactory;

    public MovieService(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<MoviesResponse>> List()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var movies = await connection.QueryAsync<Movie>(
            @"SELECT id, title, genres, CAST(imdb_score AS REAL) AS imdb_score FROM movies");

        return movies.Select(m => new MoviesResponse()
        {
            Id = m.Id,
            Title = m.Title,
            Genres = m.Genres,
            ImdbScore = m.ImdbScore,
        });
    }
}
