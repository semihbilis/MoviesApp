using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Concrete
{
    public class VoteRepository : BaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(AppDbContext? appDbContext = null) : base(appDbContext)
        {

        }

        public Movie GetMovie(int voteId) => GetById(voteId).Movie;
    }
}
