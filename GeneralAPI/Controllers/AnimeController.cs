using GeneralAPI.Entities.Models;
using GeneralAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeneralAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class AnimeController : ControllerBase
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AnimeController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAnimes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var animes = await _repositoryWrapper.Anime.GetAllAsync(pageNumber, pageSize);
        return Ok(animes);
    }

    [HttpGet("{id}", Name = "GetAnimeById")]
    public async Task<IActionResult> GetAnimeById(int id)
    {
        var anime = await _repositoryWrapper.Anime.GetByIdAsync(id);
        if (anime == null)
        {
            return NotFound();
        }
        return Ok(anime);
    }

    [HttpPost]
    public async Task<IActionResult> AddAnime([FromBody] Anime anime)
    {

        var existingGenre = await _repositoryWrapper.Anime.GetByIdAsync(anime.GenreID);
        if (existingGenre == null)
        {
            return BadRequest("El GenreID proporcionado no existe.");
        }
        await _repositoryWrapper.Anime.AddAsync(anime);
        return CreatedAtRoute("GetAnimeById", new { id = anime.EntityId }, anime);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnime(int id, [FromBody] Anime anime)
    {
        var existingAnime = await _repositoryWrapper.Anime.GetByIdAsync(id);
        if (existingAnime == null)
        {
            return NotFound();
        }

        var existingGenre = await _repositoryWrapper.Anime.GetByIdAsync(anime.GenreID);
        if (existingGenre == null)
        {
            return NotFound("El género seleccionado no existe.");
        }

        anime.EntityId = id; // Asegúrate de que el ID del anime sea el mismo que el del anime existente
        await _repositoryWrapper.Anime.UpdateAsync(anime);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnime(int id)
    {
        var anime = await _repositoryWrapper.Anime.GetByIdAsync(id);
        if (anime == null)
        {
            return NotFound();
        }

        await _repositoryWrapper.Anime.DeleteAsync(id);
        return NoContent();
    }
}