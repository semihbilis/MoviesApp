using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Concrete
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        public AppDbContext Context { get; init; }

        public DbSet<T> DbSet { get; init; }

        internal BaseRepository(AppDbContext? appDbContext = null)
        {
            Context = appDbContext ?? new AppDbContext();
            DbSet = Context.Set<T>();
        }

        public void Create(T entity) => DbSet.Add(entity);

        public void Delete(T entity) => DbSet.Remove(entity);

        public void Update(T entity) => DbSet.Entry(entity).State = EntityState.Modified;

        public IEnumerable<T> GetAll() => DbSet.AsEnumerable();

        public T GetById(int id) => DbSet.Find(id);

        public int SaveChanges() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();
    }
}
