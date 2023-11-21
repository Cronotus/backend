using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Users")]
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(40, ErrorMessage = "Maximum length for the first name is 40 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(40, ErrorMessage = "Maximum length for the last name is 40 characters.")]
        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Description { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public byte[]? PasswordHash { get; set; }

        public string? Location { get; set; }

        public ICollection<Review>? ReviewsMade { get; set; }

        public ICollection<UserReview>? ReviewsReceived { get; set; }

        public ICollection<Comment>? CommentsMade { get; set; }

        public ICollection<Reaction>? ReactionsMade { get; set; }
    }
}
