using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sims.Models.ViewModels
{
    public class SimSkillViewModel
    {
        public Sim Sim { get; set; }
        public List<SkillPoints> SkillPoints { get; set; }
    }
}
