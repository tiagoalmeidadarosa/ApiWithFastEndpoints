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
        var created = await _movieService.Create(request);

        if (created)
        {
            await SendNoContentAsync(ct);
            return;
        }

        await SendErrorsAsync(cancellation: ct);
    }
}