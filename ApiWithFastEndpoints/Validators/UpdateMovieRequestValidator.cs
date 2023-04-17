using ApiWithFastEndpoints.Models.Requests;

namespace ApiWithFastEndpoints.Validators;

public class UpdateMovieRequestValidator : Validator<UpdateMovieRequest>
{
    public UpdateMovieRequestValidator()
    {
        RuleFor(x => x.ImdbScore)
            .InclusiveBetween(0, 10)
            .WithMessage("Imdb score should be between 0 and 10.");
    }
}
