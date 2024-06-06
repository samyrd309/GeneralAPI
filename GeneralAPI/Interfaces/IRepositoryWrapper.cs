namespace GeneralAPI.Interfaces;

public interface IRepositoryWrapper
{
    IAnimeRepository Anime { get; }
    IGenreRepository Genre { get; }
    void SaveAsync();
}