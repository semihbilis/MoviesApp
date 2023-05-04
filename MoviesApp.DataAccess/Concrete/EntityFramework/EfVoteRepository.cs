using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Concrete.EntityFramework
{
    public class EfVoteRepository : EfRepositoryBase<Vote, AppDbContext>, IVoteRepository
    {
        public Movie? GetMovie(int voteId) => Get(x => x.Id == voteId)?.Movie;
    }
}
