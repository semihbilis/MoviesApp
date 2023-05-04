using MoviesApp.Entity;
using System.Text.Json.Serialization;

namespace MoviesApp.Business.Model
{
    internal class Response
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public IEnumerable<Movie> Movies { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPageCount { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalItemCount { get; set; }
    }
}
