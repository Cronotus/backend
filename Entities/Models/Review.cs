using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Column("ReviewId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User? User { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Review text is required")]
        [MaxLength(200, ErrorMessage = "Maximum length for the review text is 200 characters.")]
        public string? Text { get; set; }
    }
}
