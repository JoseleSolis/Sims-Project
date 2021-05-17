using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class SimTravelViewModel
    {
        public Sim Sim { get; set; }
        [Display(Name = "World")]
        public Guid WorldID { get; set; }
        public IEnumerable<World> Worlds { get; set; }
    }
}
