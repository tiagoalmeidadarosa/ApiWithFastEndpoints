#nullable disable

namespace ApiWithFastEndpoints.Models.Requests;

public class CreateMovieRequest
{
    public string ImdbId { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public string Rating { get; set; }
    public string Genres { get; set; }
    public int Runtime { get; set; }
    public string Country { get; set; }
    public string Language { get; set; }
    public double ImdbScore { get; set; }
    public int ImdbVotes { get; set; }
    public double MetacriticScore { get; set; }
}
