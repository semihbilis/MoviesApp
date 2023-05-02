using MoviesApp.DataAccess.Abstract;
using MoviesApp.DataAccess.Concrete;

namespace MoviesApp.DataAccess
{
    public sealed class Repository : IRepository
    {
        private readonly AppDbContext _DbContext;

        public IMovieRepository MovieRepository { get; init; }
        public IVoteRepository VoteRepository { get; init; }

        public Repository()
        {
            _DbContext = new AppDbContext();
            MovieRepository = new MovieRepository(_DbContext);
            VoteRepository = new VoteRepository(_DbContext);
        }

        public int SaveChanges() => _DbContext.SaveChanges();

        public void Dispose() => _DbContext.Dispose();
    }
}
