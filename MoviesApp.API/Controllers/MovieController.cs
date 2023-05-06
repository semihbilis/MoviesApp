using Microsoft.AspNetCore.Mvc;
using MoviesApp.API.Models;
using MoviesApp.Business.Services.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.API.Controllers
{
    /// <summary>
    /// API for movie items
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _MovieService;

        public MovieController(IMovieService movieService)
        {
            _MovieService = movieService;
        }

        /// <summary>
        /// Update movie
        /// </summary>
        /// <param name="movie">Movie</param>
        /// <returns>Movie</returns>
        [HttpPut]
        public ActionResult<Movie> Update([FromBody] Movie movie)
        {
            Movie updatedItem = _MovieService.Update(movie);
            return updatedItem != null ? Ok(updatedItem) : NotFound(null);
        }

        /// <summary>
        /// Delete movie by id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>Boolean</returns>
        [HttpDelete]
        public ActionResult<bool> Delete(int id)
        {
            bool isSuccess = _MovieService.DeleteMovieById(id);
            return isSuccess ? Ok(isSuccess) : NotFound(isSuccess);
        }

        /// <summary>
        /// Search movie by id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>Movie</returns>
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            Movie result = _MovieService.GetMovieById(id);
            return result != null ? Ok(result) : NotFound(null);
        }

        /// <summary>
        /// Get paginted movie list
        /// </summary>
        /// <param name="movieRequest">Start, limit, search text properties</param>
        /// <returns>IEnumerable</returns>
        [HttpPost]
        public ActionResult<IEnumerable<Movie>> GetPaginatedMovieList([FromBody] MovieRequest movieRequest)
        {
            if (movieRequest == null)
                return BadRequest();
            IEnumerable<Movie> result;
            if (!string.IsNullOrWhiteSpace(movieRequest.SearchText))
                result = _MovieService.GetMovieList(movieRequest.Start, movieRequest.Limit, m => m.Title.Contains(movieRequest.SearchText, StringComparison.CurrentCultureIgnoreCase));
            else
                result = _MovieService.GetMovieList(movieRequest.Start, movieRequest.Limit);
            return (result?.Any() ?? false) ? Ok(result) : NotFound(null);
        }

        /// <summary>
        /// Sync database with The Movie Datebase. Max page(20 items) is 53 in 38149. Item count 1040 in 762966
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet, Route("SyncDatabaseAsync")]
        public async Task<ActionResult<bool>> SyncDatabaseAsync()
        {
            bool isSuccess = await _MovieService.ClearAndSyncDatabaseAsync();
            return isSuccess == true ? Ok(isSuccess) : Problem("Operation Failed");
        }
    }
}
