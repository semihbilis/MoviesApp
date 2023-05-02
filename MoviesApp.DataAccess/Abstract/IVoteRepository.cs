using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Abstract
{
    public interface IVoteRepository : IBaseRepository<Vote>
    {
        Movie GetMovie(int voteId);
    }
}
