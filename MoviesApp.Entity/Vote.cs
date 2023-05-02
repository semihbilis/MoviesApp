using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entity
{
    public class Vote : BaseEntity
    {
        [MinLength(0), MaxLength(10)]
        public int Point { get; set; }
        public string Note { get; set; }

        public Movie Movie { get; set; }
    }
}
