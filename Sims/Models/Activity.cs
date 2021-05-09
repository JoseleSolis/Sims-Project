using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models
{
    public class Activity
    {
        [Key]
        public Guid ActivityID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Description { get; set; }
    }
}
