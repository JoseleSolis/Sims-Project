using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class PetDomesticUnitViewModel
    {
        public Pet Pet { get; set; }
        public Guid DomesticUnitID { get; set; }
        public string CurrentDomesticUnitName { get; set; }
        public IEnumerable<DomesticUnit> DomesticUnits { get; set; }
    }
}
