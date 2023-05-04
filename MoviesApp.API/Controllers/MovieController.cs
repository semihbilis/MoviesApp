using Microsoft.AspNetCore.Mvc;
using MoviesApp.Business.Services.Abstract;

namespace MoviesApp.API.Controllers
{
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
        /// Clear
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "SyncDatabase")]
        public async Task<IActionResult> SyncDatabaseAsync()
        {
            bool isSuccess = await _MovieService.SyncDatabaseAsync();
            if (!isSuccess)
                return Problem("Operation Failed");
            return Ok();
        }
    }
}
