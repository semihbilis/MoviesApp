using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entity
{
    public class Movie : BaseEntity
    {
        public bool IsAdult { get; set; }
        public string? BackdropPath { get; set; }
        public string GenreIds { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public int Popularity { get; set; }
        public string? PosterPath { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool IsVideo { get; set; }

        public ICollection<Vote> VoteList { get; set; }
    }
}
