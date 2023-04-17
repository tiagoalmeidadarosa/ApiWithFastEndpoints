using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Models.Responses;
using ApiWithFastEndpoints.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiWithFastEndpoints.Endpoints;

[HttpPost("movies"), AllowAnonymous]
public class CreateMovieEndpoint : Endpoint<CreateMovieRequest, MovieResponse?>
{
    private readonly MovieService _movieService;

    public CreateMovieEndpoint(MovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(CreateMovieRequest request, CancellationToken ct)
    {
        var id = await _movieService.Create(request);

        if (id == default)
        {
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        await SendAsync(new MovieResponse()
        {
            Id = id,
            Title = request.Title,
            Genres = request.Genres,
            ImdbScore = request.ImdbScore,
        }, cancellation: ct);
    }
}