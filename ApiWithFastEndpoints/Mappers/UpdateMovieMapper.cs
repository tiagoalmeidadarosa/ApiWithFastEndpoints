using ApiWithFastEndpoints.Entities;
using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Models.Responses;

namespace ApiWithFastEndpoints.Mappers;

public class UpdateMovieMapper : Mapper<UpdateMovieRequest, MovieResponse, Movie>
{
    public override Movie ToEntity(UpdateMovieRequest request) => new()
    {
        Id = request.Id,
        ImdbScore = request.ImdbScore,
    };
}
