using ApiWithFastEndpoints.Entities;
using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Models.Responses;

namespace ApiWithFastEndpoints.Mappers;

public class MovieMapper : Mapper<MovieRequest, MovieResponse, Movie>
{
    public override MovieResponse FromEntity(Movie movie) => new()
    {
        Id = movie.Id,
        Title = movie.Title,
        Genres = movie.Genres,
        ImdbScore = movie.ImdbScore,
    };
}
