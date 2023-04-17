using ApiWithFastEndpoints.Models.Requests;

namespace ApiWithFastEndpoints.Validators;

public class CreateMovieRequestValidator : Validator<CreateMovieRequest>
{
    public CreateMovieRequestValidator()
    {
        RuleFor(x => x.ImdbId)
            .NotEmpty()
            .WithMessage("Imdb id is required.")
            .MinimumLength(9)
            .WithMessage("Imdb id is too short.");

        RuleFor(x => x.ImdbScore)
            .InclusiveBetween(0, 10)
            .WithMessage("Imdb score should be between 0 and 10.");
    }
}
