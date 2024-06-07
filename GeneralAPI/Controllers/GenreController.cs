using GeneralAPI.Entities.Models;
using GeneralAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeneralAPI.Controller;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GenreController(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGenres([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var genres = await _repositoryWrapper.Genre.GetAllAsync(pageNumber, pageSize);
        return Ok(genres);
    }

    [HttpGet("{id}", Name = "GetGenreById")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        var genre = await _repositoryWrapper.Genre.GetByIdAsync(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public async Task<IActionResult> AddGenre([FromBody] Genre genre)
    {
        await _repositoryWrapper.Genre.AddAsync(genre);
        _repositoryWrapper.SaveAsync();
        return CreatedAtRoute("GetGenreById", new { id = genre.EntityId }, genre);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGenre(int id, [FromBody] Genre genre)
    {
        var existingGenre = await _repositoryWrapper.Genre.GetByIdAsync(id);
        if (existingGenre == null)
        {
            return NotFound();
        }

        genre.EntityId = id; 
        await _repositoryWrapper.Genre.UpdateAsync(genre);
        _repositoryWrapper.SaveAsync();
        return NoContent();
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        var genre = await _repositoryWrapper.Genre.GetByIdAsync(id);
        if (genre == null)
        {
            return NotFound();
        }

        await _repositoryWrapper.Genre.DeleteAsync(id);
        _repositoryWrapper.SaveAsync();
        return NoContent();
    }
}