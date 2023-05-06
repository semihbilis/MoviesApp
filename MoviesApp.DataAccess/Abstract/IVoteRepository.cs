using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Abstract
{
    public interface IVoteRepository : IRepositoryBase<Vote, AppDbContext>
    {
        Movie? GetMovie(int voteId);
    }
}
