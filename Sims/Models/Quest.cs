using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sims.Models
{
    public class Quest
    {
        [Key]
        public Guid QuestID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Please enter a positive value")]
        public double Cost { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public double Reward { get; set; }
    }
}
