using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiWithFastEndpoints.Endpoints;

[HttpDelete("movies/{id:long}"), AllowAnonymous]
public class DeleteMovieEndpoint : Endpoint<MovieRequest, EmptyResponse>
{
    private readonly MovieService _movieService;

    public DeleteMovieEndpoint(MovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(MovieRequest request, CancellationToken ct)
    {
        var deleted = await _movieService.Delete(request.Id);

        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(cancellation: ct);
    }
}