using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Abstract
{
    public interface IVoteRepository : IEntityRepository<Vote>
    {
        Movie? GetMovie(int voteId);
    }
}
