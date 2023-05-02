using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Concrete
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext? appDbContext = null) : base(appDbContext) { }

        public double GetVoteAverage(int movieId) => GetById(movieId).VoteList.Average(vote => vote.Point);
        public int GetVoteCount(int movieId) => GetById(movieId).VoteList.Count;
        public IEnumerable<Vote> GetVotes(int movieId) => GetById(movieId).VoteList.AsEnumerable();
    }
}
