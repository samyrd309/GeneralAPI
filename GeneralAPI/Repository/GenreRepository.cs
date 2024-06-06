using GeneralAPI.Entities.Models;
using GeneralAPI.Interfaces;

namespace GeneralAPI.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(PostgreDbContext context) : base(context)
        {
        }
    }
}

