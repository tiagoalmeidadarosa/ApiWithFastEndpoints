using ApiWithFastEndpoints.Entities;
using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Models.Responses;

namespace ApiWithFastEndpoints.Mappers;

public class CreateMovieMapper : Mapper<CreateMovieRequest, MovieResponse, Movie>
{
    public override Movie ToEntity(CreateMovieRequest request) => new()
    {
        ImdbId = request.ImdbId,
        Title = request.Title,
        Director = request.Director,
        Year = request.Year,
        Rating = request.Rating,
        Genres = request.Genres,
        Runtime = request.Runtime,
        Country = request.Country,
        Language = request.Language,
        ImdbScore = request.ImdbScore,
        ImdbVotes = request.ImdbVotes,
        MetacriticScore = request.MetacriticScore,
    };

    public override MovieResponse FromEntity(Movie movie) => new()
    {
        Id = movie.Id,
        Title = movie.Title,
        Genres = movie.Genres,
        ImdbScore = movie.ImdbScore,
    };
}
