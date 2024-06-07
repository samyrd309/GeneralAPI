using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GeneralAPI.Entities.Models;

[Table("Genre")]
public class Genre : IBase
{
    public int Id => EntityId;
    [Key]
    [Column("GenreID")]
    [JsonIgnore]
    public int EntityId { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public virtual ICollection<Anime> Animes { get; set; }
    [JsonIgnore]
    public bool State { get; set; } = true;
    
    public Genre()
    {
        Animes = new HashSet<Anime>();
    }

    
}