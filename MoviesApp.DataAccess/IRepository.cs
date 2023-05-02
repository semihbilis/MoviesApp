using MoviesApp.DataAccess.Abstract;

namespace MoviesApp.DataAccess
{
    public interface IRepository : IDisposable
    {
        IMovieRepository MovieRepository { get; }
        IVoteRepository VoteRepository { get; }
        int SaveChanges();
    }
}