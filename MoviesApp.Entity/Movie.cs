using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table("Movie")]
    public class Movie : BaseEntity
    {
        [JsonProperty("adult")]
        public bool IsAdult { get; set; }

        [JsonProperty("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        public IEnumerable<int> GenreIds { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("release_date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool IsVideo { get; set; }

        [JsonIgnore]
        public double VoteAverage => Votes?.Average(x => x.Point) ?? 0;

        [JsonIgnore]
        public ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();
    }
}
