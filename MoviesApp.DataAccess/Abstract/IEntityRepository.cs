using System.Linq.Expressions;

namespace MoviesApp.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        IEnumerable<T> GetList(Expression<Func<T, bool>>? filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T Update(T entity);
        bool Delete(int id);
        bool DeleteAll();
        bool SaveChanges();
    }
}
