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

    public async Task<IEnumerable<MovieResponse>> Get()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var movies = await connection.QueryAsync<Movie>(
            @"SELECT id, title, genres, CAST(imdb_score AS REAL) AS imdb_score FROM movies");

        return movies.Select(m => new MovieResponse()
        {
            Id = m.Id,
            Title = m.Title,
            Genres = m.Genres,
            ImdbScore = m.ImdbScore,
        });
    }

    public async Task<MovieResponse?> Get(long id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var movie = await connection.QuerySingleOrDefaultAsync<Movie>(@"
            SELECT id, title, genres, CAST(imdb_score AS REAL) AS imdb_score 
            FROM movies
            WHERE id = @Id", new { Id = id });

        if (movie == null)
        {
            return null;
        }

        return new MovieResponse()
        {
            Id = movie.Id,
            Title = movie.Title,
            Genres = movie.Genres,
            ImdbScore = movie.ImdbScore,
        };
    }
}
