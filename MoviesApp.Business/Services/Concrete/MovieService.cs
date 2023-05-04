using MoviesApp.Business.Model;
using MoviesApp.Business.Services.Abstract;
using MoviesApp.DataAccess.Abstract;
using MoviesApp.DataAccess.Concrete.EntityFramework;
using MoviesApp.Entity;
using Newtonsoft.Json;

namespace MoviesApp.Business.Services.Concrete
{
    public class MovieService : IMovieService
    {
        public IMovieRepository Repository { get; init; }

        public MovieService() => Repository = new EfMovieRepository();

        public Movie AddVoteToMovie(Movie movie) => Repository.Update(movie);

        public Movie GetMovieById(int id) => Repository.Get(m => m.Id == id);

        public IEnumerable<Movie> GetMovieList(int start, int limit) => Repository.GetList().Skip(start).Take(limit);

        public void RecommendSelectedMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SyncDatabaseAsync()
        {
            int pageNo = 1;
            Response response;
            do
            {
                using (HttpClient httpClient = new())
                {
                    string result;
                    try
                    {
                        result = await httpClient.GetStringAsync($"https://api.themoviedb.org/3/discover/movie?api_key=2c9bf1a176d6c00b372b23c0287fde04&language=tr-TR&sort_by=popularity.desc&include_adult=false&include_video=false&page={pageNo}&with_watch_monetization_types=flatrate");
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    if (string.IsNullOrEmpty(result))
                        return false;

                    response = JsonConvert.DeserializeObject<Response>(result);
                    if (!response?.Movies?.Any() ?? true)
                        return false;
                }
                Repository.DeleteAll();
                EfVoteRepository voteRepository = new();
                voteRepository.DeleteAll();
                voteRepository.SaveChanges();

                Repository.AddRange(response.Movies);
                pageNo++;
            } while (pageNo <= response.TotalPageCount);

            return Repository.SaveChanges();
        }
    }
}
