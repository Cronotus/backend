using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("PlayersOnEvents")]
    public class PlayersOnEvent
    {
        [Column("InstanceId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Player))]
        public Guid? PlayerId { get; set; }

        public Player? Player { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }

        public Event? Event { get; set; }
    }
}
