using MoviesApp.Entity;

namespace MoviesApp.API.Dtos
{
    public class MovieDto : Movie
    {
        public double VoteAverage { get; set; }
    }
}
