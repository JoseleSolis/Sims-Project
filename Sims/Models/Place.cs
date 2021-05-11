using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sims.Models
{
    public class Place
    {
        [Key]
        public Guid PlaceID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }
        [Range(0,double.MaxValue,ErrorMessage = "Please enter a non-negative number")]
        public double Cost { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Description { get; set; }
    }
}
