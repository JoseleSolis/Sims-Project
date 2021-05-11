using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sims.Models.ViewModels
{
    public class SimProfessionViewModel
    {
        public Sim Sim { get; set; }
        [Display(Name ="Profession")]
        public Guid ProfessionID { get; set; }
        public string CurrentProfessionName { get; set; }
        public int Level { get; set; }
        public IEnumerable<Profession> Professions { get; set; }
    }
}
