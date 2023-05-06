using MoviesApp.Entity;

namespace MoviesApp.Business.Services.Abstract
{
    public interface IVoteService
    {
        Movie? GetMovie(int voteId);
        Vote AddVoteToMovie(int movieId, Vote vote);
    }
}
