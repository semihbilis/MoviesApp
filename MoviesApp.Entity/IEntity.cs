namespace MoviesApp.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        int CreatedById { get; set; }
    }
}
