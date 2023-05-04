using Microsoft.EntityFrameworkCore;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess.Abstract
{
    public interface IRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        TContext Context { get; init; }
        DbSet<TEntity> DbSet { get; init; }
    }
}
