using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(40, ErrorMessage = "Maximum length for the first name is 40 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(40, ErrorMessage = "Maximum length for the last name is 40 characters.")]
        public string? LastName { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public ICollection<Review>? ReviewsMade { get; set; }

        public ICollection<Comment>? CommentsMade { get; set; }

        public ICollection<Reaction>? ReactionsMade { get; set; }
    }
}
