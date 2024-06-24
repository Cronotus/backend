using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Players")]
    public class Player
    {
        [Column("PlayerId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
