using MoviesApp.Business.Model;
using MoviesApp.Business.Services.Abstract;
using MoviesApp.DataAccess.Abstract;
using MoviesApp.DataAccess.Concrete.EntityFramework;
using MoviesApp.Entity;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace MoviesApp.Business.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _Repository { get; init; }

        public MovieService() => _Repository = new EfMovieRepository();

        public Movie Update(Movie movie) => _Repository.Update(movie);

        public bool DeleteMovieById(int id) => _Repository.Delete(id);

        public Movie GetMovieById(int id) => _Repository.Get(m => m.Id == id);

        public IEnumerable<Movie> GetMovieList(int start = 0, int? limit = null, Expression<Func<Movie, bool>>? filter = null)
        {
            if (limit.HasValue)
                return _Repository.GetList(filter).Skip(start).Take(limit.Value);
            else
                return _Repository.GetList(filter).Skip(start);
        }

        public void RecommendSelectedMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearAndSyncDatabaseAsync()
        {
            int pageNo = 1;
            HttpClient httpClient = new();
            _Repository.DeleteAll();
            EfVoteRepository voteRepository = new();
            voteRepository.DeleteAll();
            voteRepository.SaveChanges();
            Response? response;
            do
            {
                string result = await httpClient.GetStringAsync($"https://api.themoviedb.org/3/discover/movie?api_key=2c9bf1a176d6c00b372b23c0287fde04&language=tr-TR&sort_by=popularity.desc&include_adult=false&include_video=false&page={pageNo}&with_watch_monetization_types=flatrate");
                if (string.IsNullOrEmpty(result))
                    return false;

                response = JsonConvert.DeserializeObject<Response>(result, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                    DateFormatString = "yyyy-MM-dd"
                });

                if (!response?.Movies?.Any() ?? true)
                    return false;

                _Repository.AddRange(response?.Movies ?? Enumerable.Empty<Movie>());
                pageNo++;
            } while (pageNo <= (response?.TotalPageCount < 53 ? response.TotalPageCount : 53));

            return _Repository.SaveChanges();
        }
    }
}
