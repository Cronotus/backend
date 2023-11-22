using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [Table("PlayerInterests")]
    [Keyless]
    public class PlayerInterest
    {
        [ForeignKey(nameof(Player))]
        public Guid PlayerId { get; set; }

        public Player? Player { get; set; }

        [ForeignKey(nameof(Sport))]
        public Guid SportId { get; set; }

        public Sport? Sport { get; set; }
    }
}
