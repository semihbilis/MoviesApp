using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Abstract;
using MoviesApp.Entity;
using System.Linq.Expressions;

namespace MoviesApp.DataAccess.Concrete.EntityFramework
{
    public abstract class EfRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity, TContext>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TContext Context { get; init; }
        public DbSet<TEntity> DbSet { get; init; }

        public EfRepositoryBase()
        {
            Context = new TContext();
            DbSet = Context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var addedEntity = Context.Entry(entity);
            addedEntity.State = EntityState.Added;
            bool isSuccess = SaveChanges();
            return isSuccess ? entity : default;
        }

        public bool Delete(int id)
        {
            var deletedEntity = DbSet.Find(id);
            if (deletedEntity != null)
                DbSet.Remove(deletedEntity);
            return SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.FirstOrDefault(filter);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null ? DbSet.AsEnumerable() : DbSet.Where(filter);
        }

        public TEntity Update(TEntity entity)
        {
            var updatedEntity = Context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            updatedEntity.Entity.LastUpdateDate = DateTime.Now;
            bool isSuccess = SaveChanges();
            return isSuccess ? entity : default;
        }

        public bool DeleteAll() => DbSet.ExecuteDelete() > 0;

        public void AddRange(IEnumerable<TEntity> entities) => DbSet.AddRange(entities);

        public bool SaveChanges() => Context.SaveChanges() > 0;
    }
}
