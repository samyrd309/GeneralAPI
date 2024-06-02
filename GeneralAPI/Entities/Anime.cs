using System.ComponentModel.DataAnnotations.Schema;
using GeneralAPI.Interfaces;

namespace GeneralAPI.Entities
{
    [Table("Anime")]
    public class Anime : IBase
    {
        public int Id => AnimeID;
        public int AnimeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Studio { get; set; }
        public string Status { get; set; }
        public int Episodes { get; set; }
        public string Image { get; set; }
        public bool State { get; set;}
    }
}