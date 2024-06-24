using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Organizers")]
    public class Organizer
    {
        [Column("OrganizerId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Event>? EventsMade { get; set; }
    }
}
