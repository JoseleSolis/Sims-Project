using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class SimDomesticUnitViewModel
    {
        public Sim Sim { get; set; }

        [Display(Name = "Domestic Unit")]
        public Guid DomesticUnitID { get; set; }
        public string CurrentDomesticUnitName { get; set; }
        public IEnumerable<DomesticUnit> DomesticUnits { get; set; }
    }
}
