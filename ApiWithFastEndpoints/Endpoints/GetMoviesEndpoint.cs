using ApiWithFastEndpoints.Models.Responses;
using ApiWithFastEndpoints.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiWithFastEndpoints.Endpoints;

[HttpGet("movies"), AllowAnonymous]
public class GetMoviesEndpoint : Endpoint<EmptyRequest, IEnumerable<MoviesResponse>>
{
    private readonly MovieService _movieService;

    public GetMoviesEndpoint(MovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(EmptyRequest request, CancellationToken ct)
    {
        var movies = await _movieService.List();

        await SendAsync(movies, cancellation: ct);
    }
}