using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Events")]
    public class Event
    {
        [Column("EventId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Organizer))]
        public Guid OrganizerId { get; set; }

        public Organizer? Organizer { get; set; }

        [ForeignKey(nameof(Sport))]
        public Guid SportId { get; set; }

        public Sport? Sport { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        [MaxLength(20, ErrorMessage = "Maximum length for the event name is 20 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Event location is required")]
        [MaxLength(40, ErrorMessage = "Maximum length for the event location is 40 characters.")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Event start date is required")]
        public DateTime StartDate { get; set; }

        public int Capacity { get; set; }

        public bool Ended { get; set; }

        public ICollection<EventReview>? ReviewsGotten { get; set; }

        public ICollection<Comment>? CommentsGotten { get; set; }

        public ICollection<Player>? PlayersPresent { get; set; }
    }
}
