using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table("Vote")]
    public class Vote : BaseEntity
    {
        public int Point { get; set; }
        public string Note { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}
