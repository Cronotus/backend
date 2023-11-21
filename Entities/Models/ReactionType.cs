using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("ReactionTypes")]
    public class ReactionType
    {
        [Column("ReactionTypeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Reaction type name is a required field.")]
        [MaxLength(10, ErrorMessage = "Maximum length for the reaction type name is 10 characters.")]
        public string? Name { get; set; }
    }
}
