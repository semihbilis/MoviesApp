using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entity
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CreatedById { get; set; }
    }
}
