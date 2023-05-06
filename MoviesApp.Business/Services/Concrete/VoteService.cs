using MoviesApp.Business.Services.Abstract;
using MoviesApp.DataAccess.Abstract;
using MoviesApp.DataAccess.Concrete.EntityFramework;
using MoviesApp.Entity;

namespace MoviesApp.Business.Services.Concrete
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _Repository;
        private readonly IMovieService _MovieService;

        public VoteService(IMovieService movieService)
        {
            _MovieService = movieService;
            _Repository = new EfVoteRepository();
        }

        public Vote AddVoteToMovie(int movieId, Vote vote)
        {
            Movie movie = _Repository.Context.Movies.Find(movieId);
            if (movie == null)
                return null;
            vote.Movie = movie;
            return _Repository.Add(vote);
        }

        public Movie? GetMovie(int voteId) => _Repository.GetMovie(voteId);
    }
}
