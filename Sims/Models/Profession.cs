using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sims.Models
{
    public class Profession
    {
        [Key]
        public Guid ProfessionID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Please enter a positive value")]
        [Display(Name ="Basic Salary")]
        public double BasicSalary { get; set; }
    }
}
