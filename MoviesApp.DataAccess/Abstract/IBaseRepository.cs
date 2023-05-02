using Microsoft.EntityFrameworkCore;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Abstract
{
    public interface IBaseRepository<T> : IDisposable where T : class, IEntity, new()
    {
        AppDbContext Context { get; init; }
        DbSet<T> DbSet { get; init; }
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        int SaveChanges();
    }
}
