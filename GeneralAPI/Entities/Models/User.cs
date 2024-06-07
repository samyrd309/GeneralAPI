using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GeneralAPI.Entities.Models
{
    [Table("User")]
    public class User : IBase
    {
        public int Id => EntityId;
        [Key]
        [Column("UserID")]
        public int EntityId { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [JsonIgnore]
        public bool State { get; set; }

        public User()
        {
            State = true;
        }
    }
}