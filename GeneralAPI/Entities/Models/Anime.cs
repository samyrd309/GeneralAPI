using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GeneralAPI.Interfaces;

namespace GeneralAPI.Entities.Models
{
    [Table("Anime")]
    public class Anime : IBase
    {
        [JsonIgnore]
        public int Id => EntityId;
        [Key]
        [Column("AnimeID")]
        [JsonIgnore]
        public int EntityId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int GenreID { get; set; }
        [JsonIgnore]
        public string? Studio { get; set; }
        public string? Status { get; set; }
        public int Episodes { get; set; }
        [JsonIgnore]
        public bool State { get; set;}

        public Anime()
        {
            State = true;
            Episodes = 0;
        }
    }
}