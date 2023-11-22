using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Sports")]
    public class Sport
    {
        [Column("SportId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Sport name is required")]
        [MaxLength(20, ErrorMessage = "Maximum length for the sport name is 20 characters.")]
        public string? Name { get; set; }
    }
}
