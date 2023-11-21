using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Players")]
    public class Player
    {
        [Column("PlayerId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User? User { get; set; }

        public ICollection<PlayerInterest>? PlayerInterests { get; set; }
    }
}
