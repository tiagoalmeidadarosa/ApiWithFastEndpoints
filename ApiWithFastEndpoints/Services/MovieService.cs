using ApiWithFastEndpoints.Database;
using ApiWithFastEndpoints.Entities;
using Dapper;

namespace ApiWithFastEndpoints.Services;

public class MovieService
{
    private readonly IDbConnectionFactory _connectionFactory;

    public MovieService(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Movie>> Get()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var movies = await connection.QueryAsync<Movie>(
            @"SELECT id, title, genres, CAST(imdb_score AS REAL) AS imdb_score FROM movies");

        return movies;
    }

    public async Task<Movie?> Get(long id)
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

        return movie;
    }

    public async Task<long> Create(Movie movie)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var id = await connection.QuerySingleOrDefaultAsync<long>(@"
            INSERT INTO Movies
                (imdb_id, title, director, year, rating, genres, runtime, country, language, imdb_score, imdb_votes, metacritic_score)
            VALUES
                (@ImdbId, @Title, @Director, @Year, @Rating, @Genres, @Runtime, @Country, @Language, @ImdbScore, @ImdbVotes, @MetacriticScore)
            RETURNING id
            ", movie);

        return id;
    }

    public async Task<bool> Update(Movie movie)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var rowsAffected = await connection.ExecuteAsync(@"
            UPDATE Movies SET
                imdb_score = @ImdbScore
            WHERE
                Id = @Id",
            movie);

        return rowsAffected > 0;
    }

    public async Task<bool> Delete(long id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var rowsAffected = await connection.ExecuteAsync(@"
            DELETE FROM Movies
            WHERE Id = @Id",
            new { Id = id });

        return rowsAffected > 0;
    }
}
