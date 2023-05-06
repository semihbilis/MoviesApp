using MoviesApp.Entity;
using Newtonsoft.Json;

namespace MoviesApp.Business.Model
{
    public class Response
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public IEnumerable<Movie> Movies { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPageCount { get; set; }

        [JsonProperty("total_results")]
        public int TotalItemCount { get; set; }
    }
}
