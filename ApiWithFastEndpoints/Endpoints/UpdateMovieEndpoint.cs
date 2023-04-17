using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiWithFastEndpoints.Endpoints;

[HttpPut("movies"), AllowAnonymous]
public class UpdateMovieEndpoint : Endpoint<UpdateMovieRequest, EmptyResponse>
{
    private readonly MovieService _movieService;

    public UpdateMovieEndpoint(MovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(UpdateMovieRequest request, CancellationToken ct)
    {
        var updated = await _movieService.Update(request);

        if (!updated)
        {
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}