using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class PetEditViewModel
    {
        public Pet Pet { get; set; }
        public Guid TypeId { get; set; }
        public IEnumerable<PetType> Types { get; set; }
    }
}
