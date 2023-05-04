using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    [Table("Vote")]
    public class Vote : BaseEntity
    {
        [MinLength(0), MaxLength(10)]
        public int Point { get; set; }
        public string Note { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}
