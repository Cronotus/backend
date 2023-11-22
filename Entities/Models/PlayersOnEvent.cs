using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("PlayersOnEvents")]
    [Keyless]
    public class PlayersOnEvent
    {
        [ForeignKey(nameof(Player))]
        public Guid? PlayerId { get; set; }

        public Player? Player { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }

        public Event? Event { get; set; }
    }
}
