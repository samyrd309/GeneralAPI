using GeneralAPI.Entities.Models;
using GeneralAPI.Interfaces;

namespace GeneralAPI.Repository
{
    public class AnimeRepository : GenericRepository<Anime>, IAnimeRepository
    {
        public AnimeRepository(PostgreDbContext context) : base(context)
        {
        }
    }
}