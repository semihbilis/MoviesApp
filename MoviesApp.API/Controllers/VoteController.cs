using Microsoft.AspNetCore.Mvc;
using MoviesApp.API.Models;
using MoviesApp.Business.Services.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.API.Controllers
{
    /// <summary>
    /// API for vote
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _VoteService;

        public VoteController(IVoteService voteService)
        {
            _VoteService = voteService;
        }

        /// <summary>
        /// Vote to movie
        /// </summary>
        /// <param name="voteAddRequest">Movie id, point and vote</param>
        /// <returns>Vote</returns>
        [HttpPost]
        public ActionResult<Vote> VoteToMovie([FromBody] VoteAddRequest voteAddRequest)
        {
            if (string.IsNullOrWhiteSpace(voteAddRequest.Note) || voteAddRequest.Point < 1 || voteAddRequest.Point > 10)
                return BadRequest(voteAddRequest);
            Vote updatedVote = _VoteService.AddVoteToMovie(voteAddRequest.MovieId, new Vote() { Note = voteAddRequest.Note, Point = voteAddRequest.Point });
            return updatedVote != null ? Ok(updatedVote) : NotFound(updatedVote);
        }
    }
}
