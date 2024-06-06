using GeneralAPI.Entities.Models;
using GeneralAPI.Interfaces;
using GeneralAPI.Repository;
using Microsoft.EntityFrameworkCore;

public static class DbServicesExtensions
{
    public static void AddPostgreServices(this IServiceCollection services, string connectionString)
    {
       services.AddDbContext<PostgreDbContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddScoped<IAnimeRepository, AnimeRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}