using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("UserReviews")]
    [Keyless]
    public class UserReview
    {
        [ForeignKey(nameof(Review))]
        public Guid ReviewId { get; set; }

        public Review? Review { get; set; }

        [ForeignKey(nameof(User))]
        public string? TargetId { get; set; }

        public User? Target { get; set; }
    }
}
