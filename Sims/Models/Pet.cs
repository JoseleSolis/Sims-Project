using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sims.Models
{
    public class Pet
    {
        [Key]
        public Guid PetID { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }
        public string TypeName { get; set; }
        public PetType Type { get; set; }
        
    }
}
