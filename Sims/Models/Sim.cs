using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Sims.Models
{
    public class Sim
    {
        [Key]
        public Guid SimID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a money value")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public double Money { get; set; }

        public string Gender { get; set; }
        [Display(Name = "Life Stage")]
        public string LifeStage { get; set; }

    }
}
