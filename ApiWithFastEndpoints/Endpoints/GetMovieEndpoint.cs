using ApiWithFastEndpoints.Mappers;
using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Models.Responses;
using ApiWithFastEndpoints.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiWithFastEndpoints.Endpoints;

[HttpGet("movies/{id:long}"), AllowAnonymous]
public class GetMovieEndpoint : Endpoint<MovieRequest, MovieResponse, MovieMapper>
{
    private readonly MovieService _movieService;

    public GetMovieEndpoint(MovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(MovieRequest request, CancellationToken ct)
    {
        var movie = await _movieService.Get(request.Id);

        if (movie is null)
        {
            await SendNotFoundAsync(cancellation: ct);
            return;
        }

        await SendAsync(Map.FromEntity(movie), cancellation: ct);
    }
}