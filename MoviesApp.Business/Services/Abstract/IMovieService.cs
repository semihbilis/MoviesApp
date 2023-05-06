using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;
using System.Linq.Expressions;

namespace MoviesApp.Business.Services.Abstract
{
    public interface IMovieService
    {
        Task<bool> ClearAndSyncDatabaseAsync();
        IEnumerable<Movie> GetMovieList(int start = 0, int? limit = null, Expression<Func<Movie, bool>>? filter = null);
        Movie GetMovieById(int id);
        bool DeleteMovieById(int id);
        Movie Update(Movie movie);
        void RecommendSelectedMovie(Movie movie);
    }
}
