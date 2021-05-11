using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models
{
    public class DomesticUnit
    {
        [Key]
        public Guid DomesticUnitID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name{ get; set; }
        [Required(ErrorMessage = "Please enter a number of rooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a non-negative value")]
        [Display(Name ="Number of rooms")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Please enter a number of bathrooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a non-negative value")]
        [Display(Name = "Number of bathrooms")]
        public int BathroomNumber { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Description { get; set; }
   }
}
