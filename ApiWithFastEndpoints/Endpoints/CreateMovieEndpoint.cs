using ApiWithFastEndpoints.Mappers;
using ApiWithFastEndpoints.Models.Requests;
using ApiWithFastEndpoints.Models.Responses;
using ApiWithFastEndpoints.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiWithFastEndpoints.Endpoints;

[HttpPost("movies"), AllowAnonymous]
public class CreateMovieEndpoint : Endpoint<CreateMovieRequest, MovieResponse, CreateMovieMapper>
{
    private readonly MovieService _movieService;

    public CreateMovieEndpoint(MovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(CreateMovieRequest request, CancellationToken ct)
    {
        var entity = Map.ToEntity(request);
        var id = await _movieService.Create(entity);

        if (id == default)
        {
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        entity.Id = id;

        await SendAsync(Map.FromEntity(entity), cancellation: ct);
    }
}