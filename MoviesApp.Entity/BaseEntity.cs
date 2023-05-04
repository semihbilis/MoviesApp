using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entity
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }
    }

    public interface IEntity
    {
        int Id { get; set; }
        int CreatedById { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
