using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class PetEditViewModel
    {
        public Pet Pet { get; set; }
        [Display(Name = "Type")]
        public Guid TypeId { get; set; }
        public IEnumerable<PetType> Types { get; set; }
    }
}
