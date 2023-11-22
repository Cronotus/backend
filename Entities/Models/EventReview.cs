using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("EventReviews")]
    [Keyless]
    public class EventReview
    {
        [ForeignKey(nameof(Review))]
        public Guid ReviewId { get; set; }

        public Review? Review { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid TargetId { get; set; }

        public Event? Target { get; set; }
    }
}
