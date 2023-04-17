#nullable disable

namespace ApiWithFastEndpoints.Models.Requests;

public class UpdateMovieRequest
{
    public long Id { get; set; }
    public double ImdbScore { get; set; }
}
