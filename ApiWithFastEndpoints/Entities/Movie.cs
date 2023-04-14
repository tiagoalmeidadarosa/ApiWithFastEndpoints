#nullable disable

namespace ApiWithFastEndpoints.Entities;

public class Movie
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Genres { get; set; }
    public double ImdbScore { get; set; }
}
