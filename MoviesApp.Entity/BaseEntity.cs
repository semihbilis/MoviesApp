using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entity
{
    public abstract class BaseEntity : IEntity
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonIgnore, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-T-HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [JsonIgnore, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-T-HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdateDate { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }
    }

    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? LastUpdateDate { get; set; }
    }
}
