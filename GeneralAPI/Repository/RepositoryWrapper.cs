using GeneralAPI.Repository;

namespace GeneralAPI.Interfaces;

public class RepositoryWrapper : IRepositoryWrapper
{
    private PostgreDbContext _context;
    private IAnimeRepository _anime;
    private IGenreRepository _genre;

    public RepositoryWrapper(PostgreDbContext context, IAnimeRepository anime, IGenreRepository genre)
    {
        _context = context;
        _anime = anime;
        _genre = genre;
    }
    public IAnimeRepository Anime
    {
        get
        {
            if (_anime == null)
            {
                _anime = new AnimeRepository(_context);
            }

            return _anime;
        }
    }

    public IGenreRepository Genre
    {
        get
        {
            if (_genre == null)
            {
                _genre = new GenreRepository(_context);
            }

            return _genre;
        }
    }

    public void SaveAsync()
    {
        _context.SaveChangesAsync();
    }
}