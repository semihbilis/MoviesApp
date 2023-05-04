using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.Business.Services.Abstract
{
    public interface IVoteService
    {
        public IVoteRepository Repository { get; init; }
        Movie? GetMove(int voteId);
    }
}
