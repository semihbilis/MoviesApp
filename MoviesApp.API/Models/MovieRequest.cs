namespace MoviesApp.API.Models
{
    public class MovieRequest
    {
        public int Start { get; set; }
        public int? Limit { get; set; }
        public string SearchText { get; set; }
    }
}
