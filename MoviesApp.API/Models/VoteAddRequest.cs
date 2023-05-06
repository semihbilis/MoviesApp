using System.ComponentModel.DataAnnotations;

namespace MoviesApp.API.Models
{
    public class VoteAddRequest
    {
        public int MovieId { get; set; }
        public int Point { get; set; }
        public string Note { get; set; }
    }
}
