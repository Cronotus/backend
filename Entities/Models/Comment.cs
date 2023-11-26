using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Column("CommentId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }

        public Event? Event { get; set; }

        [Required(ErrorMessage = "Comment text is required")]
        [MaxLength(300, ErrorMessage = "Maximum length for the comment text is 300 characters.")]
        public string? Text { get; set; }

        [Required(ErrorMessage = "Comment creation time is required")]
        public DateTime Time { get; set; } = DateTime.Now;

        public ICollection<Reaction>? Reactions { get; set; }
    }
}
