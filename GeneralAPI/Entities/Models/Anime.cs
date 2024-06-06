using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralAPI.Interfaces;

namespace GeneralAPI.Entities.Models
{
    [Table("Anime")]
    public class Anime : IBase
    {
        public int Id => EntityId;
        [Key]
        [Column("AnimeID")]
        public int EntityId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; } = null!;
        public string? Studio { get; set; }
        public string? Status { get; set; }
        public int Episodes { get; set; }
        public bool State { get; set;}

        public Anime()
        {
            State = true;
            Episodes = 0;
        }
    }
}