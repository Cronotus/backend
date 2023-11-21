using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("PlayerInterests")]
    public class PlayerInterest
    {
        [Column("PlayerInterestId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Sport))]
        public Guid SportId { get; set; }

        public Sport? Sport { get; set; }
    }
}
