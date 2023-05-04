using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Concrete.EntityFramework
{
    public class EfMovieRepository : EfRepositoryBase<Movie, AppDbContext>, IMovieRepository
    {
        public double GetVoteAverage(int movieId) => Get(x=>x.Id==movieId)?.Votes.Average(vote => vote.Point) ?? 0;
        public int GetVoteCount(int movieId) => Get(x => x.Id == movieId)?.Votes.Count ?? 0;
        public IEnumerable<Vote> GetVotes(int movieId) => Get(x => x.Id == movieId)?.Votes.AsEnumerable() ?? Enumerable.Empty<Vote>();
    }
}
