using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Reactions")]
    public class Reaction
    {
        [Column("ReactionId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Comment))]
        public Guid CommentId { get; set; }

        public Comment? Comment { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }

        [ForeignKey(nameof(ReactionType))]
        public Guid ReactionTypeId { get; set; }

        public ReactionType? ReactionType { get; set; }
    }
}
