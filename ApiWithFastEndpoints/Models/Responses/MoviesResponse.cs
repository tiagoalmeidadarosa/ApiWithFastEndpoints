#nullable disable

namespace ApiWithFastEndpoints.Models.Responses;

public class MoviesResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Genres { get; set; }
    public double ImdbScore { get; set; }
}
