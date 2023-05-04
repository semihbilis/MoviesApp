using MoviesApp.Business.Services.Abstract;
using MoviesApp.DataAccess.Abstract;
using MoviesApp.DataAccess.Concrete.EntityFramework;
using MoviesApp.Entity;

namespace MoviesApp.Business.Services.Concrete
{
    public class VoteService : IVoteService
    {
        public IVoteRepository Repository { get; init; }

        public VoteService() => Repository = new EfVoteRepository();

        public Movie? GetMove(int voteId) => Repository.GetMovie(voteId);
    }
}
