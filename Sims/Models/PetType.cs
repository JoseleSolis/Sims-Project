using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models
{
    public class PetType
    {
        [Key]
        public Guid TypeID { get; set; }
        [Required(ErrorMessage ="Enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter a description")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Description { get; set; }
    }
}
