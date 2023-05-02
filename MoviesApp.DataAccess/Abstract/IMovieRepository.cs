using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Abstract
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        int GetVoteCount(int movieId);
        double GetVoteAverage(int movieId);
        IEnumerable<Vote> GetVotes(int movieId);
    }
}
