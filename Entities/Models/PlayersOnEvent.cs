using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("PlayersOnEvents")]
    public class PlayersOnEvent
    {
        [ForeignKey(nameof(Player))]
        public Guid[]? PlayerIds { get; set; }

        public ICollection<Player>? Players { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }

        public Event? Event { get; set; }
    }
}
