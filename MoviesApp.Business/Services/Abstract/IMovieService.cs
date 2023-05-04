using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.Business.Services.Abstract
{
    public interface IMovieService
    {
        IMovieRepository Repository { get; init; }
        Task<bool> SyncDatabaseAsync();
        IEnumerable<Movie> GetMovieList(int start, int limit);
        Movie GetMovieById(int id);
        Movie AddVoteToMovie(Movie movie);
        void RecommendSelectedMovie(Movie movie);
    }
}
