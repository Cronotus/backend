using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("EventPictures")]
    public class EventPicture
    {
        [Column("EventPictureId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }

        public Event? Event { get; set; }

        public string? PictureUrl { get; set; }

    }
}
